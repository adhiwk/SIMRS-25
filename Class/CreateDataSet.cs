using System;
using System.IO;
using System.Linq;
using System.Data;
using System.Reflection;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace SIMRS25.Class
{
    public class CreateObjectDataset
    {
        /*
         * Example how to use
         * var data = new List<KitirDto>
         *   {
         *   new KitirDto { TglRegistrasi = "2025-04-04", NoRkmMedis = "123456", 
         *   NmPasien = "Budi", NmDokter = "Dr. Siti", NoRawat = "RW001" },
         *   new KitirDto { TglRegistrasi = "2025-04-05", NoRkmMedis = "654321", 
         *   NmPasien = "Ani", NmDokter = "Dr. Budi", NoRawat = "RW002" }
         *   };

         *   var helper = new DatasetHelper();
         *   DataSet dataset = helper.CreateDatasetFromDto(data);
         */
        public static DataSet CreateDatasetListDto<T>(IEnumerable<T> dataList, 
            string datasetName = "DynamicDataset", 
            string tableName = "DynamicTable")
        {
            DataSet dataSet = new DataSet(datasetName);
            DataTable dataTable = new DataTable(tableName);

            if (dataList == null)
                return dataSet;

            PropertyInfo[] properties = typeof(T).GetProperties();

            // Buat kolom berdasarkan properti DTO
            foreach (var prop in properties)
            {
                dataTable.Columns.Add(prop.Name, prop.PropertyType);
            }

            // Isi data ke dalam DataTable
            foreach (var item in dataList)
            {
                var row = dataTable.NewRow();
                foreach (var prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                dataTable.Rows.Add(row);
            }

            dataSet.Tables.Add(dataTable);
            return dataSet;
        }
        public static DataSet CreateDatasetFromDtos(params (string TableName, IEnumerable<object> DataList)[] dtoTables)
        {
            var dataSet = new DataSet("DynamicDataset");

            foreach (var (tableName, dataList) in dtoTables)
            {
                if (dataList == null || !dataList.Any()) continue;

                var firstItem = dataList.First();
                var itemType = firstItem.GetType();
                var props = itemType.GetProperties();

                var table = new DataTable(tableName);
                foreach (var prop in props)
                {
                    var columnType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                    table.Columns.Add(prop.Name, columnType);
                }

                foreach (var item in dataList)
                {
                    var row = table.NewRow();
                    foreach (var prop in props)
                    {
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                    }
                    table.Rows.Add(row);
                }

                dataSet.Tables.Add(table);
            }

            return dataSet;
        }
        public static DataSet CreateDatasetDto(object dto,
            string dsName,
            string dtName)
        {
            var dataSet = new DataSet(dsName);
            var dataTable = new DataTable(dtName);
            var props = dto.GetType().GetProperties();
            // Tambahkan kolom ke DataTable
            foreach (var prop in props)
            {
                dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            // Tambahkan data ke baris
            var row = dataTable.NewRow();
            foreach (var prop in props)
            {
                row[prop.Name] = prop.GetValue(dto) ?? DBNull.Value;
            }
            dataTable.Rows.Add(row);
            dataSet.Tables.Add(dataTable);
            return dataSet;
        }

        public static void GenerateSchemaFromDto(object dto, string fileName, string dsName, string dtName)
        {
            var ds = CreateDatasetDto(dto, dsName, dtName);
            string savePath = Path.Combine(Application.StartupPath, "Dataset", fileName);
            // Tulis file XSD yang bisa di-load di Crystal Report
            ds.WriteXml(savePath, XmlWriteMode.WriteSchema);
            //ds.WriteXmlSchema(savePath); 
        }
         public void SaveDatasetToFile(DataSet dataSet, string filePath, string format = "xml")
        {
            /*
             * example how to use
             *  string xmlPath = "dataset.xml";
             *   string jsonPath = "dataset.json";

             *  SaveDatasetToFile(dataset, xmlPath, "xml");
             *   SaveDatasetToFile(dataset, jsonPath, "json");
             */ 
            string extension = format.ToLower();

            if (extension == "xml")
            {
                dataSet.WriteXml(filePath, XmlWriteMode.WriteSchema);
            }
            else if (extension == "json")
            {
                var json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
                File.WriteAllText(filePath, json);
            }
            else
            {
                throw new ArgumentException("Format tidak didukung. Gunakan 'xml' atau 'json'.");
            }
        }
    }
}
