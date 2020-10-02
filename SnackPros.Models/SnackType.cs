using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SnackPros.Models
{
    public class SnackType
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        [Display(Name = "Snack Type")]
        public string Name { get; set; }
    }
}
