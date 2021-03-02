using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D.API.Model
{
    public class notification
    {
        public string orderid { get; set; }
        public string teritorrycode { get; set; }
        public double  dblNetAmnt { get; set; }
        public int status { get; set; }
        
    }

    public class updateNotification
    {
        public List<notification> notification { get; set; }

    }
}
