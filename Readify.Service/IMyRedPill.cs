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
        string ReverseWord(string word);

        [OperationContract]
        long FibonacciNumber(long n);

        [OperationContract]
        TriangleType WhatShapeIsThis(int a, int b, int c);
    }
    
    [DataContract]
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
}
