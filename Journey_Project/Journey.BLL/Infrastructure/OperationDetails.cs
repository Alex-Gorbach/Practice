using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This class will store information about the success of the operation. The Succedeed property indicates,
// the operation is successful, and the properties Message and Property will store the corresponding message
// about the error and the property on which the error occurred.

namespace Journey.BLL.Infrastructure
{
    public class OperationDetails
    {
        public OperationDetails(bool succedeed, string message,string prop)
        {
            Succedeed = succedeed;
            Message = message;
            Property = prop;
        }

        public bool Succedeed { get; private set; }
        public string Message { get; private set; }
        public string Property { get; private set; }
    }
}
