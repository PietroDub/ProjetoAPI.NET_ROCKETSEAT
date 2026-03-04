using System.Net;

namespace ProductClientHub.Exceptions.ExceptionsBase
{   
    //criando exceção
    public abstract class ProductClientException : SystemException
    {
        public ProductClientException(string errorMessage) : base(errorMessage)
        {
          
        }

        public abstract List<string> GetErrors();
        //exceções
        public abstract HttpStatusCode GetHttpStatusCode();
    }
}
