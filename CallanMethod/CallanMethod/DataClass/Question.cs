using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallanMethod.DataClass
{
   public  class Question
    {
        public String ID_Question { get; set; }
        public String Name { get; set; }
        public String Answer { get; set; }
        public String block { get; set; }

        public Question()
        {
        }

        public Question(String ID_Q, String Name, String Answer, String block)
        {
            this.ID_Question = ID_Q;
            this.Name = Name;
            this.Answer = Answer;
            this.block = block;
        }

    }
}
