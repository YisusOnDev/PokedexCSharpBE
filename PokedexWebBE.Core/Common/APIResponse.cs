﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexWebBE.Core.Common
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class APIResponse
    {
        public bool Success { get; set; }
        public String ExceptionMessage { get; set; }
        public APIResponse()
        {
            this.Success = true;
        }

        public APIResponse(String exceptionMessage)
        {
            this.Success = false;
            this.ExceptionMessage = exceptionMessage;
        }

        public APIResponse(Exception ex)
        {
            this.Success = false;
            this.ExceptionMessage = ex.Message;
        }
        
    }
}
