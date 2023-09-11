using System;
using System.Collections.Generic;

#nullable disable

namespace Utility.Models
{
    public partial class Radio
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? GenreId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
