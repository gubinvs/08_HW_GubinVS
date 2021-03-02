using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace _08_HW_GubinVS_2._0
{
    class Program
    {
        /// Создать прототип информационной системы, в которой есть возможност работать со структурой организации
        /// В структуре присутствуют департаменты и сотрудники
        /// Каждый департамент может содержать не более 1_000_000 сотрудников.
        /// 
        /// У каждого департамента есть поля: 
        /// 1. Наименование, 
        /// 2. Дата создания,
        /// 3. Количество сотрудников числящихся в нём 
        /// (можно добавить свои пожелания)
        /// 
        /// У каждого сотрудника есть поля: 
        /// 1. Фамилия, 
        /// 2. Имя, 
        /// 3. Возраст, 
        /// 4. Департамент в котором он числится,
        /// 5. Уникальный номер, 
        /// 6. Размер оплаты труда, 
        /// 7. Количество закрепленным за ним проектов.
        ///
        /// В данной информаиционной системе должна быть возможность 
        /// - импорта и экспорта всей информации в xml и json
        /// Добавление, удаление, редактирование сотрудников и департаментов
        /// 
        /// * Реализовать возможность упорядочивания сотрудников в рамках одного департамента 
        /// по нескольким полям, например возрасту и оплате труда
        /// 
        ///  №     Имя       Фамилия     Возраст     Департамент     Оплата труда    Количество проектов
        ///  1   Имя_1     Фамилия_1          23         Отдел_1            10000                      3 
        ///  2   Имя_2     Фамилия_2          21         Отдел_2            20000                      3 
        ///  3   Имя_3     Фамилия_3          22         Отдел_1            20000                      3 
        ///  4   Имя_4     Фамилия_4          24         Отдел_1            10000                      3 
        ///  5   Имя_5     Фамилия_5          22         Отдел_2            20000                      3 
        ///  6   Имя_6     Фамилия_6          22         Отдел_1            10000                      3 
        ///  7   Имя_7     Фамилия_7          23         Отдел_1            20000                      3 
        ///  8   Имя_8     Фамилия_8          23         Отдел_1            30000                      3 
        ///  9   Имя_9     Фамилия_9          21         Отдел_1            30000                      3 
        /// 10  Имя_10    Фамилия_10          21         Отдел_2            10000                      3 
        /// 
        /// 
        /// Упорядочивание по одному полю возраст
        /// 
        ///  №     Имя       Фамилия     Возраст     Департамент     Оплата труда    Количество проектов
        ///  2   Имя_2     Фамилия_2          21         Отдел_2            20000                      3 
        /// 10  Имя_10    Фамилия_10          21         Отдел_2            10000                      3 
        ///  9   Имя_9     Фамилия_9          21         Отдел_1            30000                      3 
        ///  3   Имя_3     Фамилия_3          22         Отдел_1            20000                      3 
        ///  5   Имя_5     Фамилия_5          22         Отдел_2            20000                      3 
        ///  6   Имя_6     Фамилия_6          22         Отдел_1            10000                      3 
        ///  1   Имя_1     Фамилия_1          23         Отдел_1            10000                      3 
        ///  8   Имя_8     Фамилия_8          23         Отдел_1            30000                      3 
        ///  7   Имя_7     Фамилия_7          23         Отдел_1            20000                      3 
        ///  4   Имя_4     Фамилия_4          24         Отдел_1            10000                      3 
        /// 
        ///
        /// Упорядочивание по полям возраст и оплате труда
        /// 
        ///  №     Имя       Фамилия     Возраст     Департамент     Оплата труда    Количество проектов
        /// 10  Имя_10    Фамилия_10          21         Отдел_2            10000                      3 
        ///  2   Имя_2     Фамилия_2          21         Отдел_2            20000                      3 
        ///  9   Имя_9     Фамилия_9          21         Отдел_1            30000                      3 
        ///  6   Имя_6     Фамилия_6          22         Отдел_1            10000                      3 
        ///  3   Имя_3     Фамилия_3          22         Отдел_1            20000                      3 
        ///  5   Имя_5     Фамилия_5          22         Отдел_2            20000                      3 
        ///  1   Имя_1     Фамилия_1          23         Отдел_1            10000                      3 
        ///  7   Имя_7     Фамилия_7          23         Отдел_1            20000                      3 
        ///  8   Имя_8     Фамилия_8          23         Отдел_1            30000                      3 
        ///  4   Имя_4     Фамилия_4          24         Отдел_1            10000                      3 
        /// 
        /// 
        /// Упорядочивание по полям возраст и оплате труда в рамках одного департамента
        /// 
        ///  №     Имя       Фамилия     Возраст     Департамент     Оплата труда    Количество проектов
        ///  9   Имя_9     Фамилия_9          21         Отдел_1            30000                      3 
        ///  6   Имя_6     Фамилия_6          22         Отдел_1            10000                      3 
        ///  3   Имя_3     Фамилия_3          22         Отдел_1            20000                      3 
        ///  1   Имя_1     Фамилия_1          23         Отдел_1            10000                      3 
        ///  7   Имя_7     Фамилия_7          23         Отдел_1            20000                      3 
        ///  8   Имя_8     Фамилия_8          23         Отдел_1            30000                      3 
        ///  4   Имя_4     Фамилия_4          24         Отдел_1            10000                      3 
        /// 10  Имя_10    Фамилия_10          21         Отдел_2            10000                      3 
        ///  2   Имя_2     Фамилия_2          21         Отдел_2            20000                      3 
        ///  5   Имя_5     Фамилия_5          22         Отдел_2            20000                      3 
        /// 



        static void Main(string[] args)
        {
            #region Режим работы программы

            //do
            //{
            //    Console.WriteLine(
            //        "Необходимо выбрать режим работы:\n" +
            //        "1. Создать сотрудников рандомным способом\n" +
            //        "2. Режим добавления данных из консоли\n" +
            //        "3. Режим удаления данных\n" +
            //        "4. Режим редактирования данных\n" +
            //        "5. Режим сортировки данных\n"
            //        );
            //    switch (Convert.ToInt32(Console.ReadLine()))
            //    {
            //        case 1:
            //          Console.WriteLine("Режим формирования данных рандомным способом");
            //         RandomCreate(AddPath(), AddIntWorker());
            //            break;
            //        case 2:
            //            Console.WriteLine("Режим добавления данных из консоли");
            //          Create(AddPath());
            //            break;
            //        case 3:
            //            Console.WriteLine("Режим удаления данных");
            //           Delete(AddPath());
            //            break;
            //        case 4:
            //            Console.WriteLine("Режим редактирования данных");
                        Edit();
            //            break;
            //        case 5:
            //            Console.WriteLine("Режим сортировки данных");
            //            string path = @"C:\08_HW_GubinVS\company.xml";
            //            SortAge(path);
            //            break;

            //        default:
            //            Console.WriteLine("Команда не распознана!");
            //            break;
            //    }

            //} while (true);
            #endregion Режим работы программы

        }





        /// <summary>
        /// Метод десиарилазации данных о компании json из файла
        /// </summary>
        private static Company JsonDeserializer(string fileJson)
        {
            string json = File.ReadAllText(fileJson);
            Company com = JsonConvert.DeserializeObject<Company>(json);
            return com;
        }

        /// <summary>
        /// Сортировка сотрудников по возрасту в рамках одного департамента
        /// </summary>
        private static void SortAge(string path)
        {
            // Инициализация класса заголовок таблицы и печать заголовка в консоли
            Heading head = new Heading();
            head.PrintHeading();
            Company newcom = DeserializeXML(path);
            // Сортировка сотрудников по возрасту в рамках одного департамента
            newcom.SortAgeWorker();
            // Вывод в консоль результата сортировки
            newcom.PrintCompany();
        }

        /// <summary>
        /// Json сериализация
        /// </summary>
        /// <param name="newcom"></param>
        private static void JsonSerialize(Company newcom)
        {
            string json = JsonConvert.SerializeObject(newcom);
            File.WriteAllText(@"C:\08_HW_GubinVS_2.0\company.json", json);
        }

        /// <summary>
        /// Метод возвращает введенное с консоли значение - полный путь к файлу для сериализации
        /// </summary>
        /// <returns></returns>
        private static string AddPath()
        {
            Console.WriteLine("Введите полный путь к файлу для сериализации данных");
            string path = @"C:\08_HW_GubinVS_2.0\company.xml";//Console.ReadLine();
            return path;
        }

        /// <summary>
        /// Метод возвращает введенное из консоли количество для генерации сотрудников
        /// </summary>
        /// <returns></returns>
        private static int AddIntWorker()
        {
            Console.WriteLine("Введите необходимое количество сотрудников:");
            int worker = 10; //Convert.ToInt32(Console.ReadLine());
            return worker;
        }

        /// <summary>
        /// Метод удаления данных
        /// </summary>
        /// <param name="path"></param>
        private static void Delete(string path)
        {
            // Режим удаления данных по выбранному параметру:
            Console.WriteLine(
                "Необходимо выбрать режим работы:\n" +
                "1. Удалить департамент\n" +
                "2. Удалить сотрудника по фамилии\n"
                );
            switch (Convert.ToInt32(Console.ReadLine()))
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
        private static void Edit()
        {
            Console.WriteLine(
                "Необходимо выбрать данные для редактирования:\n" +
                "1. Редактировать данные департамента \n" +
                "2. Редактировать данные сотрудника \n" 
                );
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                        Console.WriteLine("Режим редактирования данных департамента:");
                        Company com = DeserializeXML(AddPath());
                        com.PrintCompany();
                        com.EditDepartament( ConsoleNewDep());
                        com.PrintCompany();
                        SerializeXML(AddPath(), com);
                    break;
                case 2:
                    Console.WriteLine("Режим редактирования данных сотрудника:");
                    Company newcom = DeserializeXML(AddPath());
                    newcom.PrintCompany();
                    newcom.EditWorker(ConsoleAddWorker());
                    newcom.PrintCompany();
                    //SerializeXML(AddPath(), newcom);
                    
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
        private static Departament ConsoleNewDep()
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
            dep.Date = new DateTime(eyar,month,day);

            return dep;

        }

        /// <summary>
        /// Метод принимет с консоли данные структуры и возвращает заполненныю
        /// </summary>
        private static Worker ConsoleAddWorker()
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
        private static void DeleteDep(string path, string depname)
        {

            // Инициализация класса заголовок таблицы и печать заголовка в консоли
            Heading head = new Heading();
            head.PrintHeading();

            Company newcom = DeserializeXML(path);
            // Печать данных сериализации в консоль
            newcom.PrintCompany();
            // Удаление департамента наименование которого введенно с консоли
            //newcom.DeleteDep(depname);
 
            Console.WriteLine();
            // Печать обновленных данных в консоль
            newcom.PrintCompany();
            // Сериализация новых данных в файлы xml и jason
            SerializeXML(path, newcom);
            JsonSerialize(newcom);
        }

        /// <summary>
        /// Метод принимает данные о фамилии сотрудника и удаляет сотрудников с данной фамилией
        /// метод принимает путь к файлу для десиарилизации данных и фамилию сотрудника
        /// </summary>
        /// <param name="path">Фамилия сотрудника</param>
        private static void DeleteSurname(string path, string surname)
        {
            // Инициализация класса заголовок таблицы и печать заголовка в консоли
            Heading head = new Heading();
            head.PrintHeading();

            Company newcom = DeserializeXML(path);
            // Печать данных сериализации в консоль
            newcom.PrintCompany();
            // Удаление сотрудника данными введенными с консоли
            //newcom.DeleteSurname(surname);
            Console.WriteLine();
            // Печать обновленных данных в консоль
            newcom.PrintCompany();
            // Сериализация новых данных в файлы xml и jason
            SerializeXML(path, newcom);
        }

        /// <summary>
        /// Метод добавления сотрудника данными введенными с консоли.
        /// Метод считывает данные из файла xml, заполняет данные о работнике введенные в консоль и сериализует данные в файл xml и jason
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        private static void Create(string path)
        {
            Company newcom = DeserializeXML(path);
            
            // Печать данных сериализации в консоль
            newcom.PrintCompany();
            // Добавление нового сотрудника данными введенными с консоли
            newcom.AddWorker(Worker());
            // Печать обновленных данных в консоль
            newcom.PrintCompany();
            // Сериализация новых данных в файлы xml и jason
            SerializeXML(path, newcom);
            JsonSerialize(newcom);
        }

        /// <summary>
        /// Метод принимает значение int (количество сотрудников), заполняет данные о сотрудниках
        /// сгенерировав случайным образом их данные, выводит результат в консоль и сириализует данные в XML файл
        /// </summary>
        /// <param name="number">Необходимое количество сотрудников</param>
        /// <param name="path">Путь к файлу для сериализации</param>
        private static void RandomCreate(string path, int number)
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
            JsonSerialize(com);
        }

        /// <summary>
        /// Метод десериализации данных из файла XML
        /// </summary>
        /// <param name="path">Путь к файлу с данными для десиарелазиции</param>
        /// <returns></returns>
        private static Company DeserializeXML(string path)
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
        private static void SerializeXML(string path, Company com)
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
        private static Worker Worker()
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
        private static string AddConsoleDep()
        {
            Console.WriteLine("Введите наименование департамента");
           string depname = Console.ReadLine();
            return depname;
        }

        /// <summary>
        /// Метод возвращает считанную с консоли фамилию сотрудника
        /// </summary>
        /// <returns></returns>
        private static string AddConsoleSurName()
        {
            Console.WriteLine("Введите фамилию сотрудника");
            string surname = Console.ReadLine();
            return surname;

        }
    }
}
