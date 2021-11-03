using MyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Data
{
    public class PostMemRepository
    {
        static List<Post> posts = new List<Post>();
        private static int Contador = 1;


        static PostMemRepository()
        {
            posts = new List<Post>
            {
                new Post{Id = Contador++, Titulo = "Vasco perdeu", Conteudo = "Não é novidade...", DataPublicacao = DateTime.Now.AddDays(-3) },
                new Post{Id = Contador++, Titulo = "Flamengo ganhou", Conteudo = "Mengão Malvadão na área...", DataPublicacao = DateTime.Now.AddDays(-2) },
            };
        }

        public static List<Post> SelecionarTodos()
        {
            return posts;
        }

        public static void Adicionar(Post post)
        {
            post.Id = Contador++;
            posts.Add(post);
            
        }

        public static Post SelecionarPorId(int id)
        {
            return posts.FirstOrDefault(x => x.Id == id);
        }

        public static void Editar(int id, Post post)
        {
            foreach (var item in posts)
            {
                if(item.Id == id)
                {
                    item.Titulo = post.Titulo;
                    item.Conteudo = post.Conteudo;
                    item.DataPublicacao = post.DataPublicacao;
                    break;
                }
            }
        }

        public static void Excluir(int id)
        {
            posts.Remove(SelecionarPorId(id));
        }
    }
}
