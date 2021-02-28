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
            if (ChekDepName(worker.DepartamentName))
            {
                this.Workers.Add(new Worker()
                {
                    Number = this.Workers.Count + 1,
                    DepartamentName = worker.DepartamentName,
                    SurName = worker.SurName,
                    Name = worker.Name,
                    Age = worker.Age,
                    Salary = worker.Salary,
                    QuantityProjects = worker.QuantityProjects,
                    WorkerId = Guid.NewGuid()
                }
                );

            }
            else
            {
                Random ran = new Random();
                this.Departaments.Add(
                    new Departament()
                    {
                        DepartamentName = worker.DepartamentName,
                        Date = new DateTime(ran.Next(2000, 2020), ran.Next(1, 12), ran.Next(28))
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
        /// Метод принимает кол-во сотрудников которых необходимо создать.
        /// </summary>
        /// <param name="depname">Наименование департамента</param>
        public void AddWorker(string depname, string surname, string name, int age, int salary, int progects)
        {
            // если такой департамент есть в базе, добавляется сотрудник, если нет добавляется департамент
            if (ChekDepName(depname)) 
            {
                this.Workers.Add(new Worker() 
                        {
                            Number = this.Workers.Count+1,
                            DepartamentName = depname,
                            SurName = surname,
                            Name = name,
                            Age = age,
                            Salary = salary,
                            QuantityProjects = progects,
                            WorkerId = Guid.NewGuid()
                        }
                );
          
            }
            else
            {
                Random ran = new Random();
                this.Departaments.Add(
                    new Departament()
                    {
                        DepartamentName = depname,
                        Date = new DateTime (ran.Next(2000,2020), ran.Next(1,12), ran.Next(28))
                    });
                this.AddWorker(depname, surname, name, age, salary, progects);
            }
        }

        ///// <summary>
        ///// Метод добавления департамента
        ///// </summary>
        ///// <param name="depname">Наименование департамента</param>
        ///// <param name="date">Дата</param>
        //public void AddDepartament(string depname, DateTime date)
        //{
        //    this.Departaments.Add(
        //        new Departament()
        //            {
        //                DepartamentName = depname,
        //                Date = date
        //            }
        //        );  
        //}

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
                Console.Write($"{this.Workers[i].WorkerId, 40} |");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Метод определяет есть в базе данных такой департамент или нет
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>
        public bool ChekDepName(string depname)
        {
            return this.Departaments.Exists(x => x.DepartamentName.Contains(depname));
        }

        /// <summary>
        /// Метод возвращает индекс первого вхождения искомого департамента
        /// </summary>
        /// <param name="depname">Наименование департамена у которого определяется индекс</param>
        /// <returns></returns>
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
        /// Метод сортировки сотрудников по возрасту в рамках одного департамента
        /// </summary>
        public void SortAgeWorker()
        {

            this.Workers.Sort(new SortAge());
            
        }



        //public List<Worker> Sort()
        //{
        //   var sort = this.Workers.OrderBy(x => x.Age).ThenBy(y => y.QuantityProjects) as List<Worker>;
        //    return sort;
        //}

        //public void PrintAfteSorting(List<Worker> workers)
        //{
        //    foreach (var item in workers)
        //    {
        //        Console.Write($"{item.Number,5} |");
        //        Console.Write($"{item.SurName,15} |");
        //        Console.Write($"{item.Name,15} |");
        //        Console.Write($"{item.Age,15} |");
        //        Console.Write($"{item.DepartamentName,15} |");
        //        Console.Write($"{this.Departaments[ChekDepIndex(item.DepartamentName)].Date.ToString("d"),15} |"); // дата создания, проверка на соответствие
        //        Console.Write($"{ChekQuentityWorker(item.DepartamentName),15} |");
        //        Console.Write($"{item.Salary,15} |");
        //        Console.Write($"{item.QuantityProjects,15} |");
        //        Console.Write($"{item.WorkerId,40} |");
        //        Console.WriteLine();
        //    }
        //}


    }
}
