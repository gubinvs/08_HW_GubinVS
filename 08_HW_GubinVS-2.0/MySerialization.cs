using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace _08_HW_GubinVS_2._0
{
    /// <summary>
    /// Класс содержит методы сериализации данных программы
    /// </summary>
    class MySerialization
    {
        /// <summary>
        /// Json сериализация
        /// </summary>
        public static void JsonSerialize(string path, Company company)
        {
            string json = JsonConvert.SerializeObject(company);
            File.WriteAllText(path, json);
        }

        /// <summary>
        /// Метод десиарилазации данных о компании json из файла
        /// </summary>
        public static Company JsonDeserializer(string fileJson)
        {
            string json = File.ReadAllText(fileJson);
            Company com = JsonConvert.DeserializeObject<Company>(json);
            return com;
        }

        /// <summary>
        /// Метод сериализации данных в XML файл
        /// </summary>
        public static void SerializeXML(string path, Company company)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Company));
            using (Stream str = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                xml.Serialize(str, company);
            }
        }


        /// <summary>
        /// Метод десериализации данных из файла XML, принимает путь к файлу и возвращает заполненную структуру Company
        /// </summary>
        public static Company DeserializeXML(string path)
        {
            Company company = new Company();
            XmlSerializer newxml = new XmlSerializer(typeof(Company));

            using (Stream newstr = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                company = (Company)newxml.Deserialize(newstr);
            }

            return company;
        }

    }
}
