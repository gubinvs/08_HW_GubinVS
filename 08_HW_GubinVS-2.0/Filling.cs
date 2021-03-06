using System;

namespace _08_HW_GubinVS_2._0
{

    /// <summary>
    /// Class генерации данных
    /// </summary>
    class Filling
    {

        /// <summary>
        /// База данных имён
        /// </summary>
        static readonly string[] name;

        /// <summary>
        /// База данных фамилий
        /// </summary>
        static readonly string[] surName;

        /// <summary>
        /// База данных фамилий
        /// </summary>
        static readonly string[] departament;

        /// <summary>
        /// Генератор псевдослучайных чисел
        /// </summary>
        static Random random;

        /// <summary>
        /// Статический конструктор, в котором "хранятся"
        /// данные о именах и фамилиях баз данных firstNames и lastNames
        /// </summary>
        static Filling()
        {
            random = new Random(); // Размещение в памяти генератора случайных чисел

            // Массив имен сотрудников
            name = new string[] {
                "Агата",
                "Агнес",
                "Аделаида",
                "Аделина",
                "Алдона",
                "Алима",
                "Аманда",
                "Светлана",
                "Евгения",
                "Екатерина",
                "Полина",
                "Вероника",
                "Наталья"

            };

            // Массив фамилий сотрудников
            surName = new string[]
            {
                "Иванова",
                "Петрова",
                "Васильева",
                "Кузнецова",
                "Ковалёва",
                "Попова",
                "Пономарёва",
                "Дьячкова",
                "Коновалова",
                "Соколова",
                "Лебедева",
                "Соловьёва",
                "Козлова",
                "Волкова",
                "Зайцева",
                "Ершова",
                "Карпова",
                "Щукина",
                "Виноградова",
                "Цветкова",
                "Калинина"
            };

            // Массив наименований департаментов
            departament = new string[]
            {
                   "Финансов",
                   "Транспорта",
                   "Развития"
            };

        }

        /// <summary>
        /// Метод возвращяет массив из Наименование департамента, фамилии сотрудника, имени сотрудника
        /// </summary>
        /// <returns></returns>
        public string[] StringWorker()
        {
            string[] w = new string[3];

            w[0] = AddDepartamentName(); // Наименование департамента
            w[1] = AddSurName(); //  Фамилия сотрудника
            w[2] = AddName(); // Имя сотрудника

            return w;
        }

        /// <summary>
        /// Метод возвращает заполненный массив с возрастом сотрудника, зарплатой и количеством куррируемых проектов
        /// </summary>
        /// <returns></returns>
        public int[] IntWorker()
        {
            Random r = new Random();
            int[] w = new int[3];
            w[0] = r.Next(18, 65); // Возрвст сотрудника
            w[1] = r.Next(15000, 150000); // Зарплата сотрудника
            w[2] = r.Next(10); // Количество проектов сотрудника

            return w;
        
        }


        /// <summary>
        /// Возвращает случайно подобранное из массива имя сотрудника
        /// </summary>
        /// <returns></returns>
        public string AddName()
        {
            string name = Filling.name[Filling.random.Next(Filling.name.Length)].ToString();
            return name;
        }

        /// <summary>
        /// Возвращает случайно подобранное из массива фамилию сотрудника
        /// </summary>
        /// <returns></returns>
        public string AddSurName()
        {
            string name = Filling.surName[Filling.random.Next(Filling.surName.Length)].ToString();
            return name;
        }

        /// <summary>
        /// Возвращает случайно подобранное из массива наименование департамента
        /// </summary>
        /// <returns></returns>
        public string AddDepartamentName()
        {
            string name = Filling.departament[Filling.random.Next(Filling.departament.Length)].ToString();
            return name;
        }

    }
}

