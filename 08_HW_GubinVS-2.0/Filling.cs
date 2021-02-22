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

