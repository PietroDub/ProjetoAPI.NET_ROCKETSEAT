using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductClientHub.Communication.Responses
{
    public class ResponseAllClients
    {
        public List<ResponseClientsJson> Clients { get; set; } = new List<ResponseClientsJson>();
    }
}
