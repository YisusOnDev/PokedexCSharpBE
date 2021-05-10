using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexWebBE.Core.Common
{
    public class GenericAPIResponse<T> : APIResponse
    {
        public T Data { get; set; }
        public GenericAPIResponse()
        {

        }

        public GenericAPIResponse(T data)
        {
            this.Data = data;
        }

        public GenericAPIResponse(Exception ex) : base(ex)
        {

        }
    }
}
