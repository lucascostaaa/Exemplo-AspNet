using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Models
{
    public class Post
    {
        public Post()
        {
            DataPublicacao = DateTime.Now;
        }
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Conteudo { get; set; }

        public DateTime DataPublicacao { get; set; } 

    }
}
