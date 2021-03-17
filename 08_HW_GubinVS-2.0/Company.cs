using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _08_HW_GubinVS_2._0
{
    [Serializable]

    public class Company
    {
        /// <summary>
        /// Колллекция департаментов
        /// </summary>
        public List<Departament> Departaments { get; set; }


        /// <summary>
        /// Коллекция сотрудников
        /// </summary>
        public List<Worker> Workers { get; set; }

       
        public Company()
        {
            this.Departaments = new List<Departament>();
            this.Workers = new List<Worker>();
        }

        /// <summary>
        /// Метод принимает два массива с информацией о сотруднике и добавляет данные в коллекцию
        /// </summary>
        public void AddRandomWorker(string[] n, int[] a)
        {
            AddWorker(
                        n[0], // Наименование департамента
                        n[1], // Фамилия сотрудника
                        n[2], // Имя сотрудника
                        a[0], // Возраст сотрудника
                        a[1], // Зарплата сотрудника
                        a[2]  // Количество проектов у сотрудника
                );
 
        }

        /// <summary>
        /// Метод добавляет в базу нового сотрудника принимая заполненную структуру Worker.
        /// </summary>
        public void AddWorker(Worker worker)
        {
            // если такой департамент есть в базе, добавляется сотрудник, если нет добавляется департамент
            if (ChekInputParameters.ChekDepID(this.Departaments, worker)) // Проверить идентификатор департамента 
                //сотрудника на наличие такого департамента с аналогичным идентификатором
            {
                this.Workers.Add(new Worker()
                {
                    Number = this.Workers.Count + 1, // Номер по порядку
                    DepartamentName = worker.DepartamentName,
                    SurName = worker.SurName,
                    Name = worker.Name,
                    Age = worker.Age,
                    Salary = worker.Salary,
                    QuantityProjects = worker.QuantityProjects,
                    WorkerId = ChekInputParameters.ChekGuidWorker(this.Workers, Guid.NewGuid()),
                    DepartamentID = worker.DepartamentID
                    
                }
                ) ;

            }
            else
            {
                Random ran = new Random();
                this.Departaments.Add(
                    new Departament()
                    {
                        DepartamentName = worker.DepartamentName,
                        Date = new DateTime(ran.Next(2000, 2020), ran.Next(1, 12), ran.Next(28)),
                        DepartamentID = ChekInputParameters.ChekGuidDepartament(this.Departaments, Guid.NewGuid())
                    });
                this.AddWorker(
                    worker.DepartamentName, 
                    worker.SurName, 
                    worker.Name, 
                    worker.Age, 
                    worker.Salary,
                    worker.QuantityProjects
                    
                    );
            }
        }

        /// <summary>
        /// Метод принимает строковые поля класса, для создания сотрудника
        /// </summary>
        public void AddWorker(string depname, string surname, string name, int age, int salary, int progects)
        {
            if (ChekInputParameters.ChekDepName(this.Departaments, depname)) // если такой департамент есть
            {
                this.Workers.Add(new Worker()
                {
                    Number = this.Workers.Count + 1,
                    DepartamentName = depname,
                    SurName = surname,
                    Name = name,
                    Age = age,
                    Salary = salary,
                    QuantityProjects = progects,
                    WorkerId = ChekInputParameters.ChekGuidWorker(this.Workers, Guid.NewGuid()),
                    DepartamentID = this.Departaments[ChekInputParameters.ChekDepIndex(this.Departaments, depname)].DepartamentID
                });
            }
            else
            {
                    Random ran = new Random();
                    this.Departaments.Add(
                        new Departament()
                        {
                            DepartamentName = depname,
                            Date = new DateTime(ran.Next(2000, 2020), ran.Next(1, 12), ran.Next(28)),
                            DepartamentID = ChekInputParameters.ChekGuidDepartament(this.Departaments, Guid.NewGuid())
                        });
                    AddWorker(depname, surname, name, age, salary, progects);

            }
            
        }


        /// <summary>
        /// Метод добавления департамента
        /// </summary>
        public void AddDepartament(string depname, DateTime date)
        {
            this.Departaments.Add(
                new Departament()
                {
                     DepartamentName = depname,
                     Date = date,
                     DepartamentID = ChekInputParameters.ChekGuidDepartament(this.Departaments, Guid.NewGuid())
                }
                );
        }

        /// <summary>
        /// Метод редактирования данных департамента
        /// </summary>
        /// <param name="depname">Наименование департамента</param>
        /// <param name="date">Дата</param>
        public void EditDepartament(Departament dep)
        {
            int count = this.Departaments.Count;
            for (int i = 0; i < count; i++)
            {
                if (this.Departaments[i].DepartamentName == dep.DepartamentName)
                {
                    this.Departaments[i].DepartamentName = dep.NewDepartamentName;
                    this.Departaments[i].Date = dep.Date;
                }
            }
            int countw = this.Workers.Count;
            for (int i = 0; i < countw; i++)
            {
                if (this.Workers[i].DepartamentName == dep.DepartamentName)
                {
                    this.Workers[i].DepartamentName = dep.NewDepartamentName;
                }
            }

        }

        /// <summary>
        /// Редактирование данных сотрудника выбранного по номеру в списке
        /// </summary>
        /// <param name="worker"></param>
        public void EditWorker(Worker worker)
        {
            int count = this.Workers.Count;
            for (int i = 0; i < count; i++)
            {
                if (this.Workers[i].Number == worker.Number)
                {
                    this.Workers[i].SurName = worker.SurName;
                    this.Workers[i].Name = worker.Name;
                    this.Workers[i].Age = worker.Age;
                    this.Workers[i].Salary = worker.Salary;
                    this.Workers[i].QuantityProjects = worker.QuantityProjects;
                    this.Workers[i].DepartamentName = worker.DepartamentName;
                }
            }
            int count2 = this.Departaments.Count;
            for (int i = 0; i < count2; i++)
            {
                if (this.Departaments[i].DepartamentName == worker.DepartamentName)
                {
                    break;
                }
                else
                {
                    AddDepartament(worker.DepartamentName, new DateTime(2021,02,02));
                }
            }

        }

        /// <summary>
        /// Метод печати в консоль данных о компании
        /// </summary>
        public void PrintCompany()
        {
            int count = this.Workers.Count;
            for (int i = 0; i < count; i++)
            {
                Console.Write($"{this.Workers[i].Number, 5} |");
                Console.Write($"{this.Workers[i].SurName,15} |");
                Console.Write($"{this.Workers[i].Name,15} |");
                Console.Write($"{this.Workers[i].Age,15} |");
                Console.Write($"{this.Workers[i].DepartamentName,15} |");
                Console.Write($"{this.Departaments[ChekDepIndex(this.Workers[i].DepartamentName)].Date.ToString("d"),15} |"); // дата создания, проверка на соответствие
                Console.Write($"{ChekQuentityWorker(this.Workers[i].DepartamentName),15} |");  // Кол-во сотрудников в департаменте
                Console.Write($"{this.Workers[i].Salary, 15} |");
                Console.Write($"{this.Workers[i].QuantityProjects, 15} |");
                //Console.Write($"{this.Workers[i].WorkerId, 40} |");
                Console.WriteLine();
            }
        }

        ///// <summary>
        ///// Метод определяет есть в базе данных такой департамент или нет
        ///// </summary>

        //public bool ChekDepName(string depname)
        //{
        //    return this.Departaments.Exists(x => x.DepartamentName.Contains(depname));
        //}

        /// <summary>
        /// Метод возвращает индекс первого вхождения искомого департамента
        /// </summary>

        public int ChekDepIndex(string depname)
        {
            int count = this.Departaments.Count;
            for (int i = 0; i < count; i++)
            {
                if (this.Departaments[i].DepartamentName == depname)return i;
            }
            return -1;
        }

        /// <summary>
        /// Метод перебирает колекцию сотрудников и пересчитывает количество сотрудников в принимаемом департаменте
        /// возвращает кол-во сотрудников в департаменте
        /// </summary>
        /// <param name="depname"></param>
        /// <returns></returns>
        public int ChekQuentityWorker(string depname)
        {
            int index = 0;
            int count = this.Workers.Count;
            for (int i = 0; i < count; i++)
            {
                if (this.Workers[i].DepartamentName == depname) index++;
            }
            return index;
        }

        /// <summary>
        /// Метод выбора праметров сотрировки
        /// </summary>
        public void SortAgeWorker()
        {
          this.Workers.Sort(new SortAge());  
        }

        /// <summary>
        /// Удаление департамента и всех сотрудников которые были приписаны к нему
        /// </summary>
        /// <param name="depname"></param>
        public void DeleteDep(string depname)
        {
        
            // Удаление из коллекции департамент с входящим названием
            this.Departaments.RemoveAt(ChekInputParameters.ChekDepIndex(this.Departaments, depname));
            do
            {
                DeleteWorkerDepname(ChekInputParameters.ChekWorkerIndex(this.Workers, depname));

            } while (ChekInputParameters.ChekWorkerDep(this.Workers, depname));
           
        }

        /// <summary>
        /// Метод принимает название департамента и удаляет из коллекции сотрудника с таким департаментом
        /// </summary>
       
        public void DeleteWorkerDepname(int index)
        {
            this.Workers.RemoveAt(index);
        }

        /// <summary>
        /// Метод удаляет сотрудников с указанной фамилией
        /// </summary>
        /// <param name="surname"></param>
        public void DeleteSurname(string surname)
        {
            this.Workers.RemoveAll(x => x.SurName == surname);

        }

    }
}
