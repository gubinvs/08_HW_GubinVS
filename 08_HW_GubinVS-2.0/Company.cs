using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _08_HW_GubinVS_2._0
{
    [Serializable]
    class Company
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
        /// Метод принимает кол-во сотрудников которых необходимо создать.
        /// </summary>
        /// <param name="depname">Наименование департамента</param>
        public void AddWorker(string depname, string surname, string name, int age, int salary, int progects)
        {
            // если такой департамент есть в базе, добавляем воркера, если нет предлагаем добавить департамент
            if (ChekDepName(depname)) 
            {
                this.Workers.Add(new Worker() 
                        {
                            DepartamentName = depname,
                            SurName = surname,
                            Name = name,
                            Age = age,
                            Salary = salary,
                            QuantityProjects = progects,
                            WorkerId = Guid.NewGuid()
                
                        });
          
            }
            else
            {
                Console.WriteLine("Такого департаента не существует, сначала необходимо добавить департамент");
            }

        }

        public void AddDepartament(string depname, DateTime date)
        {
            this.Departaments.Add(
                new Departament()
                    {
                        DepartamentName = depname,
                        Date = date
                    }
                );
            
        }

        /// <summary>
        /// Метод печати в консоль данных о компании
        /// </summary>
        public void PrintCompany()
        {
            int count = this.Workers.Count;
            for (int i = 0; i < count; i++)
            {
                Console.Write($"{i+1, 5} |");
                Console.Write($"{this.Workers[i].SurName,15} |");
                Console.Write($"{this.Workers[i].Name,15} |");
                Console.Write($"{this.Workers[i].Age,15} |");
                Console.Write($"{this.Workers[i].DepartamentName,15} |");
                Console.Write($"{this.Workers[i].Age,15} |");
                Console.Write($"{this.Workers[i].Age,15} |");
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


        //public int ChekDepNameIndex(string depname)
        //{ 
            
        
        //}

    }
}
