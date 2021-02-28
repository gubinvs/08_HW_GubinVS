using System;
using System.Collections.Generic;
using System.Text;

namespace _08_HW_GubinVS_2._0
{
    class SortSalary : IComparer<Worker>
    {
        
            public int Compare(Worker x, Worker y)
            {
                if (x.Salary < y.Salary)
                {
                    return -1;
                }
                else if (x.Salary < y.Salary)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

        

    }
}
