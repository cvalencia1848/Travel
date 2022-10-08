using System;
using System.Collections.Generic;

namespace Travel.Models
{
    public partial class Libro
    {
        public Libro()
        {
            AutoresHasLibros = new HashSet<AutoresHasLibro>();
        }

        public int Id { get; set; }
        public int Editoriales { get; set; }
        public string Titulo { get; set; } = null!;
        public string Sinopsis { get; set; } = null!;
        public string NumeroPaginas { get; set; } = null!;

        public virtual Editoriale EditorialesNavigation { get; set; } = null!;
        public virtual ICollection<AutoresHasLibro> AutoresHasLibros { get; set; }
    }
}
