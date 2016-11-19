using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallanMethod
{
    public class Stage
    {
        public Int32 ID_Stage { get; set; }
        public String Name { get; set; }

        public Stage(String Name)
        {
            this.Name = Name;
            try
            {
                this.ID_Stage = Convert.ToInt32(Name);
            }
            catch(Exception e)
            {
                MainForm.Instance.contollerID.ShowMessage(e.Message); 
            }
            
        }

    }
}
