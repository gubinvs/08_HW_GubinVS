using System;
using System.Collections.Generic;
using System.Text;

namespace _08_HW_GubinVS_2._0
{
    /// <summary>
    /// Класс, методы которого выполняют проверку входных параметров введенных пользователем
    /// </summary>
    class ChekInputParameters
    {

        /// <summary>
        /// Метод принимает строку и проверяет возможость конвертирования входящей строки в тип "int32", если "true" возвращает 
        /// результат, если "false" возвращает "0"
        /// </summary>
        
        public static int MenuNumber(string number)
        {
            if (int.TryParse(number, out int newnum))
            {
                return newnum;
            }
            return 0;
        }
    }
}
