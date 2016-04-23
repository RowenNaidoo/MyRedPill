using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Readify.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMyRedPill" in both code and config file together.
    [ServiceContract(
        Name="IRedPill",
        Namespace="http://redpill-3.apphb.com/")]
    public interface IRedPill
    {
        [OperationContract(
            Action = "http://redpill-3.apphb.com/RedPill.svc/WhatIsYourToken",
            IsOneWay=false,
            Name="WhatIsYourToken")]
        Guid WhatIsYourToken();

        [OperationContract(
            Action = "http://redpill-3.apphb.com/RedPill.svc/ReverseWords",
            IsOneWay = false,
            Name = "ReverseWords")]
        [FaultContract(typeof(ArgumentNullExceptionFault))]
        string ReverseWords(string word);

        [OperationContract(
            Action = "http://redpill-3.apphb.com/RedPill.svc/FibonacciNumber",
            IsOneWay = false,
            Name = "FibonacciNumber")]
        [FaultContract(typeof(ArgumentOutOfRangeExceptionFault))]
        long FibonacciNumber(long n);

        [OperationContract(
            Action = "http://redpill-3.apphb.com/RedPill.svc/WhatShapeIsThis",
            IsOneWay = false,
            Name = "WhatShapeIsThis")]
        TriangleType WhatShapeIsThis(int a, int b, int c);
    }
    
    [DataContract(
        Name = "TriangleType",
        Namespace = "http://redpill-3.apphb.com/")]
    public enum TriangleType
    {
        [EnumMember]
        Error,

        [EnumMember]
        Equilateral,

        [EnumMember]
        Isosceles,

        [EnumMember]
        Scalene
    }

    [DataContract]
    public class ArgumentOutOfRangeExceptionFault
    {
        [DataMember]
        public string FaultMessage { get; set; }
    }

    [DataContract]
    public class ArgumentNullExceptionFault
    {
        [DataMember]
        public string FaultMessage { get; set; }
    }
}
