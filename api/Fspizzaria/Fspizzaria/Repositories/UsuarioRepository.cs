using Fspizzaria.Domains;
using Fspizzaria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Fspizzaria.Repositories
{
    public class UsuarioRepository : IUsuariosRepository
    {
        public Usuario BuscarPorEmailSenha(string email, string senha)
        {
            using (FspizzariaContext login = new FspizzariaContext())
            {
                Usuario usuarioPesquisa = login.Usuario.Where(x => x.Email == email && x.Senha == senha).FirstOrDefault();
                return usuarioPesquisa;

            }
        }

        public void CadastrarUsuario(Usuario usuario)
        {
            using (FspizzariaContext cadastra = new FspizzariaContext())
            {
                cadastra.Usuario.Add(usuario);
                cadastra.SaveChanges();
            }
        }
    }
}
