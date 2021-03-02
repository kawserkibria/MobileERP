using System;
using JA.LAST.Model;
using JA.LAST.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace JA.LAST.Facade
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FacadeLast" in both code and config file together.
    public class FacadeLast : IFacadeLast
    {
        public List<ModelLast> mDisplayItemGroup2(string strDeComID, string vstrItemGroup, string vstrDate, string vstrTDate, int intMode)
        {
            return new DalLast().mDisplayItemGroup2(strDeComID, vstrItemGroup, vstrDate, vstrTDate, intMode);
        }
        public void DoWork()
        {
        }
    }
}
