using PokedexWebBE.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexWebBE.DAL.Contracts
{
    public interface IRegisterRepository
    {
        public bool Register(User username);
    }
}
