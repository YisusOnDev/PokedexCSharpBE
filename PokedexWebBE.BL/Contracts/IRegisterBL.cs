using PokedexWebBE.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexWebBE.BL.Contracts
{
    public interface IRegisterBL
    {
        public bool Register(RegisterDTO registerDTO);
    }
}
