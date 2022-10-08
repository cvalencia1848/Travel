using System;
using System.Collections.Generic;

namespace Travel.Models
{
    public partial class Autore
    {
        public Autore()
        {
            AutoresHasLibros = new HashSet<AutoresHasLibro>();
        }

        public int Id { get; set; }
        public string Nobre { get; set; } = null!;
        public string Apellido { get; set; } = null!;

        public virtual ICollection<AutoresHasLibro> AutoresHasLibros { get; set; }
    }
}
