﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatrimonioManager.Dtos
{
    public class PatrimonioDtoOut
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        [Required]
        [StringLength(500)]
        public string Descricao { get; set; }

        public MarcaDtoOut Marca { get; set; }

        [Required]
        public int MarcaId { get; set; }
    }
}