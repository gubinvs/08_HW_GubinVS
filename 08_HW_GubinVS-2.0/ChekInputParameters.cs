using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _08_HW_GubinVS_2._0
{
    /// <summary>
    /// Класс, методы которого выполняют проверку входных параметров введенных пользователем
    /// </summary>
    class ChekInputParameters
    {

        /// <summary>
        /// Метод принимает строку и проверяет возможость конвертирования входящей строки в тип "int32", если "true" возвращает 
        /// результат, если "false" возвращает "0"
        /// </summary>
        public static int MenuNumber(string number)
        {
            if (int.TryParse(number, out int newnum))
            {
                return newnum;
            }
            return 0;
        }


        /// <summary>
        ///  Метод принимает строку из консоли и проверяет можно преобразовать в 
        /// </summary>
        /// <returns></returns>
        public static bool ChekUInt(string number)
        {
            if (uint.TryParse(number, out uint newnum))
            {
                return true;
            }
            return false;

        }

        /// <summary>
        ///  Метод принимает строку из консоли и проверяет можно преобразовать в 
        /// </summary>
        /// <returns></returns>
        public static bool ChekInt(string number)
        {
            if (int.TryParse(number, out int newnum))
            {
                return true;
            }
            return false;

        }


        /// <summary>
        /// Метод проверяет наличие файла по принимающему пути и возвращает true - при наличие файла и false -при его отсутствии
        /// </summary>

        public static bool FileExists(string path)
        {
            if (File.Exists(path))
            {
                return true;
            }
            else
            {
                return false;
            }
        
        }


        /// <summary>
        /// Метод проверяет возможность преобразования введенных данных с консоли в дату
        /// </summary>
        /// <returns></returns>
        public static bool ChekDataTime(string text)
        {
            if (DateTime.TryParse(text, out DateTime data))
            {
                return true;
            }
            return false;
        
        }


        /// <summary>
        /// Проверка на уникальность, если уникальный то возвращает guid в противном случае генерирует новый и снова проверка
        /// </summary>
   
        public static Guid ChekGuid(List<Worker> workers, Guid guid)
        {
            Guid newguid = Guid.NewGuid();
            int count = workers.Count;
            
            for (int i = 0; i < count; i++)
            {
                if (workers[i].WorkerId  == guid)
                {
                    ChekGuid(workers, newguid);
                }
            }
            return guid;
            
        }


    }
}
