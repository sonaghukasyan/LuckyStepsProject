using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyStepsProject.DataFile
{
    internal class DataAccess<T> : IDataAccess<T>
    {
        private DirectoryInfo DirectoryInfo;
        public string DirectoryName { get; set; }

        public DataAccess(string name)
        {
            this.DirectoryName = name;
            DirectoryInfo = new DirectoryInfo(this.DirectoryName);
            DirectoryInfo.Create();
        }
        public void Save(IEnumerable<T> list)
        {
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };

            string JsonData = JsonConvert.SerializeObject(list, jsonSerializerSettings);
            byte[] data = Encoding.UTF8.GetBytes(JsonData);

            
            using (FileStream fileStream = new FileStream(DirectoryName + "/File.txt", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                fileStream.Write(data, 0, data.Length);
            }
        }

        public IEnumerable<T> Read()
        {
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };

            byte[] data;
            using (FileStream fileStream = new FileStream(DirectoryName + "/File.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                data = new byte[fileStream.Length];
                fileStream.Write(data, 0, data.Length);
            }

           string JsonData = Encoding.Default.GetString(data);
           IEnumerable<T> list = JsonConvert.DeserializeObject<IEnumerable<T>>(JsonData, jsonSerializerSettings);

           if(list == null)
            {
                list = new List<T>();
            }

            return list;
        }
    }
}
