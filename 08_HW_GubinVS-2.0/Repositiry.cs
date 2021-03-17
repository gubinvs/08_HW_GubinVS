using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace _08_HW_GubinVS_2._0
{
    class Repositiry
    {

        /// <summary>
        /// Метод принимает значение int (количество сотрудников), заполняет данные о сотрудниках
        /// сгенерировав случайным образом их данные, выводит результат в консоль и сириализует данные в XML файл
        /// </summary>
        public static void RandomCreate(string path, uint number)
        {
            // Инициализация класса заголовок таблицы и печать заголовка в консоли
            Heading head = new Heading();
            head.PrintHeading();

            // Заполнение данных о сотрудниках
            Company com = new Company();
            for (uint i = 0; i < number; i++)
            {
                com.AddRandomWorker(new Filling().StringWorker(), new Filling().IntWorker());
            }
            //Печать данных в консоль
            com.PrintCompany();
            // Сериализация данных в файл XML
            MySerialization.SerializeXML(path, com);
          
        }

        /// <summary>
        /// Метод возвращает введенное с консоли значение - полный путь к файлу xml
        /// </summary>
        public static string AddPath()
        {
            Console.WriteLine("Введите полный путь к xml файлу:");
            string path = Console.ReadLine();
            while (ChekInputParameters.FileExists(path))
            {
                string p = $@"{path}";
                return p;
            }
            Console.WriteLine("По указанному пути файла не обнаружено!");
            AddPath();
            return null;
            
        }

        /// <summary>
        /// Метод запрашивает количество создаваемых сотрудников и возвращает введенное из консоли число
        /// </summary>
        /// <returns></returns>
        public static uint AddIntWorker()
        {
            Console.WriteLine("Введите необходимое количество сотрудников:");
            string str = Console.ReadLine();
            if (ChekInputParameters.ChekUInt(str))
            {
                uint worker = Convert.ToUInt32(str);
                return worker;
            }
            Console.WriteLine("Это не число!"); // Можно написать, что типо меньше 0 или слишком большое
            AddIntWorker();
            return 0;

        }


        /// <summary>
        /// Сортировка сотрудников по возрасту в рамках одного департамента
        /// </summary>
        public static void SortWorker(string path)
        {
            // Инициализация класса заголовок таблицы и печать заголовка в консоли
            Heading head = new Heading();
            head.PrintHeading();
            Company company = MySerialization.DeserializeXML(path);
            company.PrintCompany();
            // Выбор режима сортировки
            Console.WriteLine("Необходимо выбрать режим работы:");
            Console.WriteLine("" +
                "1. Сортировка сотрудников по возрасту\n" +
                "2. Сортировка по возрасту и оплате труда в рамках одного департаменты\n"
                );
            switch (ChekInputParameters.MenuNumber(Console.ReadLine()))
            {
                case 1:
                    company.SortAgeWorker();
                    company.PrintCompany();
                    break;
                case 2:
                    SortAgeEndSalary(company);
                    break;

                default:
                    break;
            }


        }


        /// <summary>
        /// Метод удаления данных
        /// </summary>
        
        public static void Delete(string path)
        {
            // Режим удаления данных по выбранному параметру:
            Console.WriteLine(
                "Необходимо выбрать режим работы:\n" +
                "1. Удалить департамент\n" +
                "2. Удалить сотрудника по фамилии\n"
                );
            switch (ChekInputParameters.MenuNumber(Console.ReadLine()))
            {
                case 1:
                    // Удаление департамента
                    DeleteDep(path, AddConsoleDep());
                    break;
                case 2:
                    // Удаление сотрудника по фамилии
                    DeleteSurname(path, AddConsoleSurName());
                    break;

                default:
                    Console.WriteLine("Команда не распознана!");
                    break;
            }
        }

        /// <summary>
        /// Метод принимает путь к файлу для сериализации и наименование департамента и удаляет все совпадения
        /// </summary>
 
        public static void DeleteDep(string path, string depname)
        {

            // Инициализация класса заголовок таблицы и печать заголовка в консоли
            Heading head = new Heading();
            head.PrintHeading();

            Company company = MySerialization.DeserializeXML(path);
            // Печать данных сериализации в консоль
            company.PrintCompany();
            // Удаление департамента наименование которого введенно с консоли
            company.DeleteDep(depname);

            Console.WriteLine();

            // Печать обновленных данных в консоль
            company.PrintCompany();

            // Сериализация новых данных в файлы xml и jason
            MySerialization.SerializeXML(path, company);
            
        }

        /// <summary>
        /// Метод возвращает наименование департаментасчитанное с консоли
        /// </summary>
        
        public static string AddConsoleDep()
        {
            Console.WriteLine("Введите наименование департамента:");
            string depname = Console.ReadLine();
            return depname;
        }

        /// <summary>
        /// Метод возвращает считанную с консоли фамилию сотрудника
        /// </summary>
        /// <returns></returns>
        public static string AddConsoleSurName()
        {
            Console.WriteLine("Введите фамилию сотрудника");
            string surname = Console.ReadLine();
            return surname;

        }


        /// <summary>
        /// Метод добавления сотрудника данными введенными с консоли.
        /// Метод считывает данные из файла xml, заполняет данные о работнике введенные в консоль и сериализует данные в файл xml и jason
        /// </summary>
    
        public static void Create(string path)
        {
            Heading head = new Heading();
            head.PrintHeading();

            Company company = MySerialization.DeserializeXML(path);
            // Печать данных сериализации в консоль
            company.PrintCompany();

            // Добавление нового сотрудника данными введенными с консоли
            company.AddWorker(Worker());
            // Печать обновленных данных в консоль
            company.PrintCompany();

            // Сериализация новых данных в файлы xml
            MySerialization.SerializeXML(path, company);
           
        }

        /// <summary>
        /// Метод добавления сотрудника данными введенными с консоли
        /// </summary>
        public static Worker Worker()
        {
            Worker w = new Worker();
            Console.WriteLine("Введите наименование департамента:");
            w.DepartamentName = Console.ReadLine();

            Console.WriteLine("Введите фамилию сотрудника:");
            w.SurName = Console.ReadLine();

            Console.WriteLine("Введите имя сотрудника:");
            w.Name = Console.ReadLine();

            Console.WriteLine("Введите возраст сотрудника:");
            w.Age = AddIntConsole();

            Console.WriteLine("Введите размер оплаты труда сотрудника:");
            w.Salary = AddIntConsole();

            Console.WriteLine("Введите количество проектов у сотрудника:");
            w.QuantityProjects = AddIntConsole();

            return w;
        }

        /// <summary>
        /// Метод считывает значение возраст сотрудника из консоли и возвращает int
        /// </summary>
        /// <returns></returns>
        private static int AddIntConsole()
        { 
            
            string str = Console.ReadLine();
            if (ChekInputParameters.ChekInt(str))
            {
                int age = Convert.ToInt32(str);
                return age;
            }
            Console.WriteLine("Некорректные данные!");
            AddIntConsole();
            return -1;
            
        }

        /// <summary>
        /// Метод редактирования данных
        /// </summary>
        public static void Edit()
        {
            Console.WriteLine(
                "Необходимо выбрать данные для редактирования:\n" +
                "1. Редактировать данные департамента \n" +
                "2. Редактировать данные сотрудника \n"
                );
            switch (ChekInputParameters.MenuNumber(Console.ReadLine()))
            {
                case 1:
                    EditDep();
                    break;

                case 2:
                    EditWorker();
                    break;

                default:
                    Console.WriteLine("Команда не распознана!");
                    break;
            }
        }


        /// <summary>
        /// Метод редактирования данных о департаменте
        /// </summary>
        private static void EditDep()
        {
            Console.WriteLine("Режим редактирования данных департамента:");

            // Считывание данных из файла
            Company company = MySerialization.DeserializeXML(AddPath());

            // Печать считанных данных в консоль
            company.PrintCompany();

            // Редактирование данных о департаменте полученных из консоли
            company.EditDepartament(ConsoleNewDep());

            // печать в консоль обновленных данных
            company.PrintCompany();

            // Сохранение обновленных данных в файл
            MySerialization.SerializeXML(AddPath(), company);

        }


        /// <summary>
        /// Метод заполняет с консоли и возвращает заполненную структуру департамента,
        /// метод применяется для сбора информации о корректируемом департаменте
        /// </summary>
        private static Departament ConsoleNewDep()
        {
            Departament dep = new Departament();
            dep.DepartamentName = AddConsoleDep();

            Console.WriteLine("Новое наименование департамента:");
            dep.NewDepartamentName = AddConsoleDep();

            dep.Date = AddDataTimeConsole();

            return dep;

        }

        /// <summary>
        /// Метод принимает данные из консоли и возвращает дату
        /// </summary>
        /// <returns></returns>
        private static DateTime AddDataTimeConsole()
        {
            Console.WriteLine("Введите дату в формате: ГГГГ,ММ,ДД");
            string text = Console.ReadLine();
            if (ChekInputParameters.ChekDataTime(text))
            {
                DateTime data = Convert.ToDateTime(text);
                return data;
            }
            Console.WriteLine("Некорректные данные!");
            AddDataTimeConsole();
            return new DateTime();

        }


        /// <summary>
        /// Метод редактирования данных сотрудника
        /// </summary>
        private static void EditWorker()
        {
            Console.WriteLine("Режим редактирования данных сотрудника:");
            // Чтение данных из файла
            Company company = MySerialization.DeserializeXML(AddPath());

            // Печать данных из файла в консоль
            company.PrintCompany();

            // Редактирование данных сотрудника
            company.EditWorker(ConsoleAddWorker());

            // Печать обновленных данных
            company.PrintCompany();

            // Запись обновленных данных в файл
            MySerialization.SerializeXML(AddPath(), company);

        }


        /// <summary>
        /// Метод принимет с консоли данные структуры и возвращает заполненныю
        /// </summary>
        public static Worker ConsoleAddWorker()
        {
            Worker w = new Worker();

            Console.WriteLine("Введите № редактируемого сотрудника");
            w.Number = AddIntConsole();

            Console.WriteLine("Фамилия сотрудника");
            w.SurName = Console.ReadLine();

            Console.WriteLine("Имя сотрудника");
            w.Name = Console.ReadLine();

            Console.WriteLine("Возраст сотрудника");
            w.Age = AddIntConsole();

            Console.WriteLine("Департамент сотрудника");
            w.DepartamentName = Console.ReadLine();

            Console.WriteLine("Зарплата сотрудника");
            w.Salary = AddIntConsole();

            Console.WriteLine("Проектов у сотрудника");
            w.QuantityProjects = AddIntConsole();

            return w;
        }


        /// <summary>
        /// Метод принимает данные о фамилии сотрудника и удаляет сотрудников с данной фамилией
        /// метод принимает путь к файлу для десиарилизации данных и фамилию сотрудника
        /// </summary>
        /// <param name="path">Фамилия сотрудника</param>
        public static void DeleteSurname(string path, string surname)
        {
            // Инициализация класса заголовок таблицы и печать заголовка в консоли
            Heading head = new Heading();
            head.PrintHeading();

            //  Чтение данных из файла
            Company company = MySerialization.DeserializeXML(path);

            //// Печать данных сериализации в консоль
            company.PrintCompany();

            // Удаление сотрудника данными введенными с консоли
            company.DeleteSurname(surname);
            // Разделение данных в консоли, для лучшего восприятия
            Console.WriteLine();

            // Печать обновленных данных в консоль
            company.PrintCompany();

            // Сериализация новых данных в файлы xml
            MySerialization.SerializeXML(path, company);
        }


        /// <summary>
        /// Метод метод сортировки по возрасту и оплате труда в рамках одного департамента
        /// </summary>
        /// <returns></returns>
        public static void SortAgeEndSalary(Company company)
        {
            var sort = company.Workers.OrderBy(x => x.Age).ThenBy(y => y.Salary);

            foreach (var item in sort)
            {
                Console.Write($"{item.Number,5} |");
                Console.Write($"{item.SurName,15} |");
                Console.Write($"{item.Name,15} |");
                Console.Write($"{item.Age,15} |");
                Console.Write($"{item.DepartamentName,15} |");
                Console.Write($"{company.Departaments[company.ChekDepIndex(item.DepartamentName)].Date.ToString("d"),15} |"); // дата создания, проверка на соответствие
                Console.Write($"{company.ChekQuentityWorker(item.DepartamentName),15} |");
                Console.Write($"{item.Salary,15} |");
                Console.Write($"{item.QuantityProjects,15} |");
                Console.Write($"{item.WorkerId,40} |");
                Console.WriteLine();
            }

        }


        /// <summary>
        /// Метод считывает данные из файла и выводит результат в консоль
        /// </summary>
        /// <param name="path"></param>
        public static void Read(string path)
        {
            Console.WriteLine("\n\n");
            // Инициализация класса заголовок таблицы и печать заголовка в консоли
            Heading head = new Heading();
            head.PrintHeading();

            Company company = MySerialization.DeserializeXML(path);
            // Печать данных сериализации в консоль
            company.PrintCompany();
            Console.WriteLine("\n\n");

        }


    }
}
