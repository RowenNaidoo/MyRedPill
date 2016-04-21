using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Readify.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MyRedPill" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MyRedPill.svc or MyRedPill.svc.cs at the Solution Explorer and start debugging.
    public class MyRedPill : IMyRedPill
    {
        public string DoWork()
        {
            return "balls";
        }

        public TriangleType test()
        {
            return new TriangleType();
        }
    }
}
