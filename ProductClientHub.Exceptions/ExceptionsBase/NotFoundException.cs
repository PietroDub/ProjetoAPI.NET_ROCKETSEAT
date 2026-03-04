using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProductClientHub.Exceptions.ExceptionsBase
{
    public class NotFoundException : ProductClientException
    {
        public NotFoundException(string errorMessage) : base(errorMessage)
        {
        }

        //devolvendo a lista de UM ITEM (MESSAGE)
        public override List<string> GetErrors() => [Message];

        public override HttpStatusCode GetHttpStatusCode()
        {
            throw new NotImplementedException();
        }
    }
}
