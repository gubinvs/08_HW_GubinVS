using System;
using System.Collections.Generic;
using System.Text;

namespace _08_HW_GubinVS_2._0
{
    /// <summary>
    /// Класс содержит коллекцию идентификаторов сотрудников с привязкой к идентификатору департамента.
    /// Идентификатор департамента содержит список идентификаторов сотрудников, которые приписаны к данному департаменту
    /// </summary>
    class CompanyID
    {
        /// <summary>
        /// Идентификаторы Workers
        /// </summary>
        public Guid WorkerID { get; set; }

        /// <summary>
        /// Идентификаторы Departaments
        /// </summary>
        public Guid DepartamentID { get; set; }

        /// <summary>
        /// Коллекция идентификаторов сотрудников с привязкой к идентификатору департамента
        /// </summary>
        public List<CompanyID> CompanyIDs { get; set; }


        public CompanyID() 
        {
            this.CompanyIDs = new List<CompanyID>();
        }



    }
}
