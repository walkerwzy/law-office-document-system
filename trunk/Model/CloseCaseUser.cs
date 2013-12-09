using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WZY.Model
{
    [Serializable]
    public class CloseCaseInfo
    {
        public CloseCaseInfo()
        {
            
        }
        public CloseCaseInfo(int id, string name)
        {
            this.id = id;
            this.name = name;
            this.time = DateTime.Now;
        }
        public CloseCaseInfo(int id, string name, DateTime time)
            : this(id, name)
        {
            this.time = time;
        }

        public int id { get; set; }
        public string name { get; set; }
        public DateTime time { get; set; }
    }
}
