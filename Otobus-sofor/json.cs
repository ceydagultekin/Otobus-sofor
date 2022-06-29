using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace Otobus_sofor
{
    class json
    {
        public static void PrintTime(object obj)
        {

            string data = JsonSerializer.Serialize(obj);
            using (StreamWriter sw = new StreamWriter("C:"))
            {
                sw.WriteLine(data);
            }
        }
        public static void PrintDriver(object obj)
        {

            string data = JsonSerializer.Serialize(obj);
            using (StreamWriter sw = new StreamWriter("C:"))
            {
                sw.WriteLine(data);
            }
        }






    }
}
