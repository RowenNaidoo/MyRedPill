using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Readify.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMyRedPill" in both code and config file together.
    [ServiceContract]
    public interface IMyRedPill
    {
        [OperationContract]
        string DoWork();

        [OperationContract]
        TriangleType test();
    }

    [DataContract]
    public enum TriangleType
    {
        a=1,
        b=2,
        c=3
    }
}
