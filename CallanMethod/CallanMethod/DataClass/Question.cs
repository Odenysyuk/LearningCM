using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallanMethod.DataClass
{
    class Question
    {
        public Int32 ID_Question { get; set; }
        public String Name { get; set; }
        public String Answer { get; set; }
        public Block block { get; set; }

    }
}
