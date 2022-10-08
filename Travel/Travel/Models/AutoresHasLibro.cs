using System;
using System.Collections.Generic;

namespace Travel.Models
{
    public partial class AutoresHasLibro
    {
        public int Id { get; set; }
        public int IdAutores { get; set; }
        public int IdLibros { get; set; }

        public virtual Autore IdAutoresNavigation { get; set; } = null!;
        public virtual Libro IdLibrosNavigation { get; set; } = null!;
    }
}
