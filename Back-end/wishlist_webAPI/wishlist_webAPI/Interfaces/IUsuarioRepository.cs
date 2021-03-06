using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wishlist_webAPI.Domains;

namespace wishlist_webAPI.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> ListarTodos();
        void Cadastrar(Usuario NovoUsuario);
        void Deletar(int IdDeletar);
        Usuario Login(string email, string senha);
    }
}
