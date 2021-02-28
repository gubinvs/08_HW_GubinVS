using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;

namespace _08_HW_GubinVS_2._0
{
    [Serializable]

    public class Worker
    {
        /// <summary>
        /// Номер по порядку
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Фамилия сотрудника
        /// </summary>
        public string SurName { get; set; }

        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возраст сотрудника
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Размер оплаты труда сотрудника
        /// </summary>
        public int Salary { get; set; }

        /// <summary>
        /// Количество выполняемых проектов сотрудником
        /// </summary>
        public int QuantityProjects { get; set; }

        /// <summary>
        /// Наименование департамента в котором он числится
        /// </summary>
        public string DepartamentName { get; set; }

        /// <summary>
        /// Уникальный идентификационный номер сотрудника
        /// </summary>
        public Guid WorkerId { get; set; }


        public Worker() 
        { 
        }
    }
}
