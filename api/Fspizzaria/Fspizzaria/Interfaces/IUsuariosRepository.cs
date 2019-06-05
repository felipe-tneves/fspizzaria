using Fspizzaria.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fspizzaria.Interfaces
{
    interface IUsuariosRepository
    {
        Usuario BuscarPorEmailSenha(string email, string senha);

        //cadastra qualquer tipo de usuario 
        void CadastrarUsuario(Usuario usuario);

    }
}
