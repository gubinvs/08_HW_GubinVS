using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;

namespace _08_HW_GubinVS_2._0
{
    [Serializable]

    public class Departament
    {
        /// <summary>
        /// Наименование департамента
        /// </summary>
        public string DepartamentName { get; set; }

        /// <summary>
        ///  Новое наименование департамента
        /// </summary>
        public string NewDepartamentName { get; set; }

        /// <summary>
        /// Дата создания департамента
        /// </summary>
        public DateTime Date { get; set; }


        /// <summary>
        /// Количество сотрудников в департаменте
        /// </summary>
        public int QuentityWorker { get; set; }


    }
}
