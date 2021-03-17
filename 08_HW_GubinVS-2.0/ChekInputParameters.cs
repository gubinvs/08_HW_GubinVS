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
   
        public static Guid ChekGuidWorker(List<Worker> workers, Guid guid)
        {
            Guid newguid = Guid.NewGuid();
            int count = workers.Count;
            
            for (int i = 0; i < count; i++)
            {
                if (workers[i].WorkerId  == guid)
                {
                    ChekGuidWorker(workers, newguid);
                }
            }
            return guid;
            
        }

        /// <summary>
        /// Проверка на уникальность идентификатора в колллекции Departaments, если уникальный то возвращает guid 
        /// в противном случае генерирует новый и снова проверяет до тех пор пока не будет уникальным.
        /// </summary>

        public static Guid ChekGuidDepartament(List<Departament> departaments, Guid guid)
        {
            Guid newguid = Guid.NewGuid();
            int countDep = departaments.Count;

            for (int i = 0; i < countDep; i++)
            {
                if (departaments[i].DepartamentID == guid)
                {
                    ChekGuidDepartament(departaments, newguid);
                }
            }
            return guid;

        }

        /// <summary>
        /// Метод проверяет есть такой идентификатор департамента с коллекции или нет, если да, в противном случае нет
        /// </summary>
      
        public static bool ChekDepID(List<Departament> departaments, Worker worker)
        {
           
            int countDep = departaments.Count;

            for (int i = 0; i < countDep; i++)
            {
                if (departaments[i].DepartamentID == worker.DepartamentID)
                {
                    return true;
                }
            }
            return false;

        }


        /// <summary>
        /// Метод принимает название департамента и коллекцию департаментов, ищет соответствие по названию 
        /// и возвращает индекс первого вхождения. Если соответствий не найдено возвращает -1ю
        /// </summary>
      
        public static int ChekDepIndex(List<Departament> dep, string depname)
        {
            
            int countDep = dep.Count;

            for (int i = 0; i < countDep; i++)
            {
                if (dep[i].DepartamentName == depname)
                {
                    return i;
                }
            }
            return -1;
            

        }


        /// <summary>
        /// Метод принимает название департамента , проверяет коллекцию департамента на наличие 
        /// соответствия и если соответствие есть возвращает true, в противном случае false
        /// </summary>
        
        public static bool ChekDepName(List<Departament> dep, string depname)
        {
            int countDep = dep.Count;

            for (int i = 0; i < countDep; i++)
            {
                if (dep[i].DepartamentName == depname)
                {
                    return true;
                }
            }
            return false;

        }

        /// <summary>
        /// Метод принимает колллекцию сотрудников и наза=вание департамента,  возвращает индекс первого вхождения названия департамента
        /// </summary>

        public static int ChekWorkerIndex(List<Worker> worker, string depname)
        {

            int countDep = worker.Count;

            for (int i = 0; i < countDep; i++)
            {
                if (worker[i].DepartamentName == depname)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Метод принимает колллекцию сотрудников и название департамента,  возвращает true если такие есть и false в противном случае
        /// </summary>

        public static bool ChekWorkerDep(List<Worker> worker, string depname)
        {

            int countDep = worker.Count;

            for (int i = 0; i < countDep; i++)
            {
                if (worker[i].DepartamentName == depname)
                {
                    return true;
                }
            }
            return false;
        }


    }
}
