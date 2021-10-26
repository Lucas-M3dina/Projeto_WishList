using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
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

        public string ConsultarPerfilDir(int id_usuario)
        {
            string nome_novo = id_usuario.ToString() + ".png";
            string caminho = Path.Combine("Perfil", nome_novo);

            if (File.Exists(caminho))
            {
                byte[] bytesArquivo = File.ReadAllBytes(caminho);
                return Convert.ToBase64String(bytesArquivo);
            }

            return null;
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

        public void SalvarPerfilDir(IFormFile foto, int id_usuario)
        {
            string nome_novo = id_usuario.ToString() + ".png";

            using (var stream = new FileStream(Path.Combine("perfil", nome_novo), FileMode.Create))
            {
                foto.CopyTo(stream);
            }
        }
    }
}
