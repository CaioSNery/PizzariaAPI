using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzaria.Interface
{
    public interface ISMSService
    {
        Task EnviasSMSAsync(string numero, string mensagem);
    }
}