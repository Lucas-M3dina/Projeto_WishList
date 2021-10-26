using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wishlist_webAPI.Contexts;
using wishlist_webAPI.Domains;
using wishlist_webAPI.Interfaces;

namespace wishlist_webAPI.Repositores
{
    public class UsuarioRepository : IUsuarioRepository
    {
        WishListContext ctx = new WishListContext();
        public void Cadastrar(Usuario NovoUsuario)
        {
            ctx.Update(NovoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int IdDeletar)
        {
            Usuario UsuarioDeletar = ctx.Usuarios.Find(IdDeletar);
            ctx.Usuarios.Remove(UsuarioDeletar);
            ctx.SaveChanges();
        }

        public List<Usuario> ListarTodos()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(e => e.Email == email && e.Senha == senha);
        }
    }
}
