using Fspizzaria.Domains;
using Fspizzaria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fspizzaria.Repositories
{
    public class PizzariaRepository : IPizzariaRepository
    {
        public Pizzarias BuscarPorNome(string nome)
        {
            using (FspizzariaContext pizzaria = new FspizzariaContext())
            {
                Pizzarias pizzariaPesquisa = pizzaria.Pizzarias.FirstOrDefault(x => x.Nome == nome);
                if (pizzariaPesquisa == null)
                {
                    return null;
                }
                return pizzariaPesquisa;

            }
        }

        public void Cadastrar(Pizzarias pizzaria)
        {
            using (FspizzariaContext cadpizza = new FspizzariaContext())
            {
                cadpizza.Pizzarias.Add(pizzaria);
                cadpizza.SaveChanges();
            }
        }

        public List<Pizzarias> Listar()
        {
            using (FspizzariaContext listapizza = new FspizzariaContext())
            {
                List<Pizzarias> Lista = listapizza.Pizzarias.Include(q => q.IdCategoriaNavigation).ToList();
                foreach (var item in Lista)
                {
                    item.IdCategoriaNavigation.Pizzarias = null;
                }
                return Lista; 
            }
        }

        
    }
}
