using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDiary
{
    class HelperClasses
    {
        public static List<Classes> GetClasses(string defaultClasses)
        {

            return new List<Classes>
            {
                new Classes {Id = 0, ClassName= defaultClasses},
                new Classes {Id = 1, ClassName ="1A"},
                new Classes {Id = 2, ClassName ="1B"},
                new Classes {Id = 3, ClassName ="1C"},
                new Classes {Id = 4, ClassName ="2A"},
                new Classes {Id = 5, ClassName ="2B"},
                new Classes {Id = 6, ClassName ="2C"},
                new Classes {Id = 7, ClassName ="3A"},
                new Classes {Id = 8, ClassName ="3B"},
                new Classes {Id = 9, ClassName ="3C"}

            };
        }



    }
}
