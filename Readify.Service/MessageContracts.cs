using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace Readify.Service
{
    public class MessageContracts
    {
        [MessageContract]
        public class ReverseWords
        {
            [MessageBodyMember]
            public int x;
            [MessageBodyMember]
            public int y;
        }
    }
}