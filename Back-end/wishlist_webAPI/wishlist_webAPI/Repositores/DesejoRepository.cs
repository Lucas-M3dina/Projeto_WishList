using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wishlist_webAPI.Contexts;
using wishlist_webAPI.Domains;
using wishlist_webAPI.Interfaces;

namespace wishlist_webAPI.Repositores
{
    public class DesejoRepository : IDesejoRepository
    {
        WishListContext ctx = new WishListContext();
        public void Cadastrar(Desejo NovoDesejo)
        {
            ctx.Update(NovoDesejo);
            ctx.SaveChanges();
        }

        public void Deletar(int IdDeletar)
        {
            Desejo DesejoDeletar = ctx.Desejos.Find(IdDeletar);
            ctx.Desejos.Remove(DesejoDeletar);
            ctx.SaveChanges();
        }

        public List<Desejo> ListarTodos()
        {
            return ctx.Desejos.Include(d => d.IdUsuarioNavigation).ToList();
        }
    }
}
