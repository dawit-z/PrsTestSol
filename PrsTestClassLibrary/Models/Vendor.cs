﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsTestClassLibrary.Models
{
    public class Vendor
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Code { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        public string Address { get; set; }

        [Required]
        [MaxLength(30)]
        public string City { get; set; }

        [Required]
        [MaxLength(2)]
        public string State { get; set; }

        [Required]
        [MaxLength(5)]
        public string Zip { get; set; }

        [MaxLength(12)]
        public string Phone { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        public Vendor() { }
    }
}
