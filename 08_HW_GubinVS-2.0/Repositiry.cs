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
        /// Метод десиарилазации данных о компании json из файла
        /// </summary>
        public static Company JsonDeserializer(string fileJson)
        {
            string json = File.ReadAllText(fileJson);
            Company com = JsonConvert.DeserializeObject<Company>(json);
            return com;
        }

        /// <summary>
        /// Сортировка сотрудников по возрасту в рамках одного департамента
        /// </summary>
        public static void SortWorker(string path)
        {
            // Инициализация класса заголовок таблицы и печать заголовка в консоли
            Heading head = new Heading();
            head.PrintHeading();
            Company com = DeserializeXML(path);
            com.PrintCompany();
            // Выбор режима сортировки
            Console.WriteLine("Необходимо выбрать режим работы:");
            Console.WriteLine("" +
                "1. Сортировка сотрудников по возрасту\n" +
                "2. Сортировка по возрасту и оплате труда в рамках одного департаменты\n"
                );
            switch (ChekInputParameters.MenuNumber(Console.ReadLine()))
            {
                case 1:
                    com.SortAgeWorker();
                    com.PrintCompany();
                    break;
                case 2:
                    SortAgeEndSalary(com);
                    break;

                default:
                    break;
            }


        }

        /// <summary>
        /// Json сериализация
        /// </summary>
        /// <param name="newcom"></param>
        public static void JsonSerialize(Company newcom)
        {
            string json = JsonConvert.SerializeObject(newcom);
            File.WriteAllText(@"C:\08_HW_GubinVS_2.0\company.json", json);
        }

        /// <summary>
        /// Метод возвращает введенное с консоли значение - полный путь к файлу xml
        /// </summary>
        /// <returns></returns>
        public static string AddPath()
        {
            //Console.WriteLine("Введите полный путь к xml файлу для сериализации данных");
            string path = @"C:\08_HW_GubinVS_2.0\company.xml";//Console.ReadLine();
            return path;
        }

        /// <summary>
        /// Метод запрашивает количество создаваемых сотрудников и возвращает введенное из консоли число
        /// </summary>
        /// <returns></returns>
        public static int AddIntWorker()
        {
            Console.WriteLine("Введите необходимое количество сотрудников:");
            int worker = ChekInputParameters.MenuNumber(Console.ReadLine());
            return worker;
        }

        /// <summary>
        /// Метод удаления данных
        /// </summary>
        /// <param name="path"></param>
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
                    Console.WriteLine("Режим редактирования данных департамента:");
                    Company com = DeserializeXML(AddPath());
                    com.PrintCompany();
                    com.EditDepartament(ConsoleNewDep());
                    com.PrintCompany();
                    SerializeXML(AddPath(), com);
                    break;
                case 2:
                    Console.WriteLine("Режим редактирования данных сотрудника:");
                    Company newcom = DeserializeXML(AddPath());
                    newcom.PrintCompany();
                    newcom.EditWorker(ConsoleAddWorker());
                    newcom.PrintCompany();
                    SerializeXML(AddPath(), newcom);

                    break;

                default:
                    Console.WriteLine("Команда не распознана!");
                    break;
            }
        }

        /// <summary>
        /// Метод заполняет с консоли и возвращает заполненную структуру департамента,
        /// метод применяется для сбора информации о корректируемом департаменте
        /// </summary>
        public static Departament ConsoleNewDep()
        {
            Departament dep = new Departament();
            dep.DepartamentName = AddConsoleDep();


            Console.WriteLine("Новое наименование департамента:");
            dep.NewDepartamentName = AddConsoleDep();

            Console.WriteLine("Год в формате гггг");
            int eyar = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Месяц в формате мм");
            int month = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("День в формате дд");
            int day = Convert.ToInt32(Console.ReadLine());
            dep.Date = new DateTime(eyar, month, day);

            return dep;

        }

        /// <summary>
        /// Метод принимет с консоли данные структуры и возвращает заполненныю
        /// </summary>
        public static Worker ConsoleAddWorker()
        {
            Worker w = new Worker();
            Console.WriteLine("Введите № редактируемого сотрудника");
            w.Number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Фамилия сотрудника");
            w.SurName = Console.ReadLine();
            Console.WriteLine("Имя сотрудника");
            w.Name = Console.ReadLine();
            Console.WriteLine("Возраст сотрудника");
            w.Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Департамент сотрудника");
            w.DepartamentName = Console.ReadLine();
            Console.WriteLine("Зарплата сотрудника");
            w.Salary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Проектов у сотрудника");
            w.QuantityProjects = Convert.ToInt32(Console.ReadLine());

            return w;
        }

        /// <summary>
        /// Метод принимает путь к файлу для сериализации и наименование департамента и удаляет все совпадения
        /// </summary>
        /// <param name="path">Путь к файлу для сериализации</param>
        /// <param name="depname">Наименование департамента</param>
        public static void DeleteDep(string path, string depname)
        {

            // Инициализация класса заголовок таблицы и печать заголовка в консоли
            Heading head = new Heading();
            head.PrintHeading();

            Company com = DeserializeXML(path);
            // Печать данных сериализации в консоль
            com.PrintCompany();
            // Удаление департамента наименование которого введенно с консоли
            com.DeleteDep(depname);

            Console.WriteLine();
            // Печать обновленных данных в консоль
            com.PrintCompany();
            // Сериализация новых данных в файлы xml и jason
            SerializeXML(path, com);
            JsonSerialize(com);
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

            Company com = DeserializeXML(path);
            // Печать данных сериализации в консоль
            com.PrintCompany();
            // Удаление сотрудника данными введенными с консоли
            com.DeleteSurname(surname);
            Console.WriteLine();
            // Печать обновленных данных в консоль
            com.PrintCompany();
            // Сериализация новых данных в файлы xml и jason
            SerializeXML(path, com);
        }

        /// <summary>
        /// Метод добавления сотрудника данными введенными с консоли.
        /// Метод считывает данные из файла xml, заполняет данные о работнике введенные в консоль и сериализует данные в файл xml и jason
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public static void Create(string path)
        {
            Heading head = new Heading();
            head.PrintHeading();
            Company newcom = DeserializeXML(path);
            // Печать данных сериализации в консоль
            newcom.PrintCompany();
            // Добавление нового сотрудника данными введенными с консоли
            newcom.AddWorker(Worker());
            // Печать обновленных данных в консоль
            newcom.PrintCompany();
            // Сериализация новых данных в файлы xml и jason
            SerializeXML(path, newcom);
            //JsonSerialize(newcom);
        }

        /// <summary>
        /// Метод принимает значение int (количество сотрудников), заполняет данные о сотрудниках
        /// сгенерировав случайным образом их данные, выводит результат в консоль и сириализует данные в XML файл
        /// </summary>
        /// <param name="number">Необходимое количество сотрудников</param>
        /// <param name="path">Путь к файлу для сериализации</param>
        public static void RandomCreate(string path, int number)
        {
            // Инициализация класса заголовок таблицы и печать заголовка в консоли
            Heading head = new Heading();
            head.PrintHeading();

            // Заполнение данных о сотрудниках
            Company com = new Company();
            for (int i = 0; i < number; i++)
            {
                com.AddRandomWorker(new Filling().StringWorker(), new Filling().IntWorker());
            }
            //Печать данных в консоль
            com.PrintCompany();
            // Сериализация данных в файл  XML
            SerializeXML(path, com);
            // Сериализация данных в файл  JSON
            //JsonSerialize(com);
        }

        /// <summary>
        /// Метод десериализации данных из файла XML
        /// </summary>
        /// <param name="path">Путь к файлу с данными для десиарелазиции</param>
        /// <returns></returns>
        public static Company DeserializeXML(string path)
        {
            Company newcom = new Company();
            XmlSerializer newxml = new XmlSerializer(typeof(Company));

            using (Stream newstr = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                newcom = (Company)newxml.Deserialize(newstr);
            }

            return newcom;
        }

        /// <summary>
        /// Метод сериализации данных в XML файл
        /// </summary>
        /// <param name="path">Путь к файлу для сериалезации</param>
        /// <param name="com">Сериализуемый класс</param>
        public static void SerializeXML(string path, Company com)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Company));
            using (Stream str = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                xml.Serialize(str, com);
            }
        }

        /// <summary>
        /// Метод добавления сотрудника данными введенными с консоли
        /// </summary>
        public static Worker Worker()
        {
            Worker w = new Worker();
            Console.WriteLine("Введите наименование департамента");
            w.DepartamentName = Console.ReadLine();

            Console.WriteLine("Введите фамилию сотрудника");
            w.SurName = Console.ReadLine();

            Console.WriteLine("Введите имя сотрудника");
            w.Name = Console.ReadLine();

            Console.WriteLine("Введите возраст сотрудника");
            w.Age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите размер оплаты труда сотрудника");
            w.Salary = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите количество проектов у сотрудника");
            w.QuantityProjects = Convert.ToInt32(Console.ReadLine());

            return w;
        }

        /// <summary>
        /// Метод возвращает наиметование департаментасчитанное с консоли
        /// </summary>
        /// <returns></returns>
        public static string AddConsoleDep()
        {
            Console.WriteLine("Введите наименование департамента");
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
            // Инициализация класса заголовок таблицы и печать заголовка в консоли
            Heading head = new Heading();
            head.PrintHeading();

            Company com = DeserializeXML(path);
            // Печать данных сериализации в консоль
            com.PrintCompany();

        }


    }
}
