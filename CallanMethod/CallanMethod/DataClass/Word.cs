using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallanMethod.DataClass
{
    public class Word
    {
        public Int32 ID_Word{ get; set; }
        public String Name { get; set; }
        public String Translation { get; set; }
        public String block { get; set; }
        public String stage { get; set; }
        public String lesson { get; set; }

        public Word(Int32 ID, String Name, String Translation, String block, String stage, string lesson)
        {
            this.ID_Word = ID;
            this.Name = Name;
            this.Translation = Translation;
            this.block = block;
            this.stage = stage;
            this.lesson = lesson;
        }
    }
}
