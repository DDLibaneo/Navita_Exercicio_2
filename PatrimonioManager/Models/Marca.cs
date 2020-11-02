using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PatrimonioManager.Models
{
    public class Marca
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Index(IsUnique = true)]
        public string Nome { get; set; }
    }
}