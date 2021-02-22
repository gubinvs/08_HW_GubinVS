using System;


namespace _08_HW_GubinVS_2._0
{

    /// <summary>
    /// Класс описывающий заголовки таблицы при выводе ин
    /// </summary>
    public class Heading
    {
        /// <summary>
        /// Наименование столбцов таблицы вывода в консоль данных
        /// </summary>
        /// 

        // public string number = "Номер";
        public string number = "№ п\\п";

        public string departament = "Департамент";

        public string workerquantity = "Сотрудников";

        public string date = "Дата создания";

        public string surname = "Фамилия";

        public string name = "Имя";

        public string age = "Возраст";

        public string salary = "Оплата";

        public string namberofprojects = "Проектов";

        public string id = "Идентификатор";

        public Heading() { }


        /// <summary>
        /// Метод вывода заголовка таблицы в консоль
        /// </summary>
        public void PrintHeading()
        {
            Console.Write($"{this.number,5} |");
            Console.Write($"{this.surname,15} |");
            Console.Write($"{this.name,15} |");
            Console.Write($"{this.age,15} |");
            Console.Write($"{this.departament,15} |");
            Console.Write($"{this.date,15} |");
            Console.Write($"{this.workerquantity,15} |");
            Console.Write($"{this.salary,15} |");
            Console.Write($"{this.namberofprojects,15} |");
            Console.Write($"{this.id,40} |");
            Console.WriteLine("\n");
        }

    }
}
