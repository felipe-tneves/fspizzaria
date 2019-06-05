using Fspizzaria.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fspizzaria.Interfaces
{
    interface IPizzariaRepository
    {
        Pizzarias BuscarPorNome(string nome);
        //cadastro de pizza
        void Cadastrar(Pizzarias pizzaria);

        //lista de pizzas
        List<Pizzarias> Listar();
    }
}
