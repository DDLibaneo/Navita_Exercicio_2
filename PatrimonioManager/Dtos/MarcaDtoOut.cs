using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatrimonioManager.Dtos
{
    public class MarcaDtoOut
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nome { get; set; }
    }
}