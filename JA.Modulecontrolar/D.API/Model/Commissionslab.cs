using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D.API.Model
{
    public class Commissionslab
    {
        public string groupName { get; set; }
        public double dblFromRange { get; set; }
        public double dblToRange { get; set; }
        public double dblPercentage { get; set; }
        public string strDate { get; set; }
    }
    public class AppsVercify
    {
        public string userid { get; set; }
        public string password { get; set; }
        public int intResult { get; set; }
    }
    public class AppsVercifysumm
    {
        public List<AppsVercify> summary { get; set; }
      
    }
}
