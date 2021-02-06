using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Models
{
    class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Name { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public DateTime PublishedDate { get; set; }

        public string Description { get; set; }

    }
}
