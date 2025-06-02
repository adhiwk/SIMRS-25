using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SIMRS25.Dtos;
using SIMRS25.Class;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
namespace SIMRS25.Bpjs
{
    /// <summary>
    /// Provides methods to interact with BPJS Antrol services.
    /// </summary>
    public class AntrolServices
    {
        private static readonly HttpClient HttpClientInstance = new HttpClient();

        /// <summary>
        /// convert from base64string to get decrypt text
        /// </summary>
        private static string Decrypt(string key)
        {
            var dec = AesEncryptionService.CreateService();
            return dec.Decrypt(Convert.FromBase64String(EnvConfig.Get(key)));
        }

        /// <summary>
        /// Retrieves BPJS credentials from configuration.
        /// </summary>Dto
        private static async Task<BpjsCredentialsDto> GetCredentialsAsync()
        {
            string timestamp = await BpjsHeaders.TimeStamp();
            string consId = Decrypt("BPJS_ANTREAN_CONS_ID");
            string userKey = Decrypt("BPJS_ANTREAN_USER_KEY");
            string secretKey = Decrypt("BPJS_ANTREAN_SECRET_KEY");
            return new BpjsCredentialsDto(consId, secretKey, userKey, timestamp);
        }

        /// <summary>
        /// Configures HTTP headers for BPJS requests.
        /// </summary>
        private static void SetHeaders(HttpClient client, BpjsCredentialsDto credentials)
        {
            string signatureData = credentials.ConsId + "&" + credentials.Timestamp;

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("X-cons-id", credentials.ConsId);
            client.DefaultRequestHeaders.Add("X-Timestamp", credentials.Timestamp);
            client.DefaultRequestHeaders.Add("X-Signature", BpjsHeaders.CreateSignature(signatureData, credentials.UserKey));
            client.DefaultRequestHeaders.Add("user_key", credentials.UserKey);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Decrypts the BPJS API response.
        /// </summary>
        private static string DecryptResponse(BpjsCredentialsDto credentials, string encrypted)
        {
            string decryptionKey = $"{credentials.ConsId}{credentials.SecretKey}{credentials.Timestamp}";
            string decryptedResponse = BpjsSecurity.Decrypt(decryptionKey.Trim(), encrypted);
            return JToken.Parse(BpjsLZString.DecompressFromEncodedURIComponent(decryptedResponse))
                         .ToString(Formatting.Indented);
        }

        /// <summary>
        /// Handles the HTTP response from the BPJS API and returns the deserialized DTO.
        /// </summary>
        private static async Task<TDto> HandleResponseAsync<TDto>(HttpResponseMessage response, BpjsCredentialsDto credentials)
        {
            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(result))
                throw new InvalidOperationException("Response is empty.");

            var jsonResponse = JsonConvert.DeserializeObject<AntreanOnlineBpjsDto<JToken>>(result.Trim());

            int code = jsonResponse.metadata.code;
            if (code != 200 && code != 1)
                throw new ApplicationException($"BPJS error: {jsonResponse.metadata.message} (code: {code})");

            string finalJson = DecryptResponse(credentials, jsonResponse.response.ToString());
            Console.WriteLine(finalJson);
            return JsonConvert.DeserializeObject<TDto>(finalJson.Trim());
        }

        /// <summary>
        /// Executes a GET request to the specified BPJS URL.
        /// </summary>
        public static async Task<TDto> GetAsync<TDto>(string bpjsUrl)
        {
            var credentials = await GetCredentialsAsync();
            SetHeaders(HttpClientInstance, credentials);

            using var response = await HttpClientInstance.GetAsync(bpjsUrl.Trim());
            return await HandleResponseAsync<TDto>(response, credentials);
        }

        /// <summary>
        /// Executes a POST request to the specified BPJS URL with the provided data.
        /// </summary>
        public static async Task<TDto> PostAsync<TDto>(string bpjsUrl, object data)
        {
            var credentials = await GetCredentialsAsync();
            SetHeaders(HttpClientInstance, credentials);

            string jsonData = JsonConvert.SerializeObject(data);
            using var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            using var response = await HttpClientInstance.PostAsync(bpjsUrl.Trim(), content);
            return await HandleResponseAsync<TDto>(response, credentials);
        }
    }
}
