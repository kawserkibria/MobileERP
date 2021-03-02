using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D.API.Model
{
    public class summaryNew
    {
        public List<summary1> summary { get; set; }
        public List<details> details { get; set; }
    }
    
    public class summary1
    {
        public string approveBy { get; set; }
        public string approveDate { get; set; }
        public string date { get; set; }
        public string doctor { get; set; }
        public string id { get; set; }
        public bool isSelected { get; set; }
        public string mpo { get; set; }
        public string orderId { get; set; }
        public int status { get; set; }
        public double totalAmount { get; set; }
        public double totlaQty { get; set; }
        public string newCustomer { get; set; }
        public string reciveAddress { get; set; }
       
        
     
    }


   public class details
   {
       public string mpo { get; set; }
       public string doctorName { get; set; }
       public string groupName { get; set; }
       public string itemName { get; set; }
       public double itemPrice { get; set; }
       public double itemQuentity { get; set; }
       public double itemTotalPrice { get; set; }
       public string orderid { get; set; }
       public string slabgroupName { get; set; }
       public string date { get; set; }


   }


}
