using System;
using JA.LAST.Model;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace JA.LAST.Facade
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFacadeLast" in both code and config file together.
    [ServiceContract]
    public interface IFacadeLast
    {
        [OperationContract]
        List<ModelLast> mDisplayItemGroup2(string strDeComID, string vstrItemGroup, string vstrDate, string vstrTDate, int intMode);
        void DoWork();
    }
}
