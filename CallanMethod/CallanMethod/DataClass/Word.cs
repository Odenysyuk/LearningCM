using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallanMethod.DataClass
{
    class Word
    {
        public Int32 ID_Word{ get; set; }
        public String Name { get; set; }
        public String Translation { get; set; }
        public Block block { get; set; }
        public Stage stage { get; set; }
        public Lesson lesson { get; set; }
    }
}
