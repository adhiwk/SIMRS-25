using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMRS25.Dtos
{
    public class BpjsCredentialsDto
    {
        public string ConsId { get; set; }
        public string SecretKey { get; set; }
        public string UserKey { get; set; }
        public string Timestamp { get; set; }

        public BpjsCredentialsDto(string consId, string secretKey, string userKey, string timestamp)
        {
            ConsId = consId;
            SecretKey = secretKey;
            UserKey = userKey;
            Timestamp = timestamp;
        }
    }
}
