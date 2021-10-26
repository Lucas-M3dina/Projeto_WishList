using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wishlist_webAPI.Domains;

namespace wishlist_webAPI.Interfaces
{
    interface IDesejoRepository
    {
        List<Desejo> ListarTodos();
        void Cadastrar(Desejo NovoDesejo);
        void Deletar(int IdDeletar);
    }
}
