using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokedexWebBE.BL.Contracts;
using PokedexWebBE.BL.Implementations;
using PokedexWebBE.Core.Common;
using PokedexWebBE.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokedexWebBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        public IRegisterBL RegisterBL { get; set; }

        public RegisterController(IRegisterBL registerBL)
        {
            this.RegisterBL = registerBL;
        }

        [HttpPost]
        public GenericAPIResponse<bool> Register(RegisterDTO registerDTO) 
        {
            return RegisterBL.Register(registerDTO);
        }
    }
}
