﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Dtos
{
    public class KategoriaDto
    {

        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Nazwa { get; set; }

    }
}