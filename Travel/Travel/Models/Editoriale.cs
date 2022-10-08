using System;
using System.Collections.Generic;

namespace Travel.Models
{
    public partial class Editoriale
    {
        public Editoriale()
        {
            Libros = new HashSet<Libro>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Sede { get; set; } = null!;

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
