using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Model
{
    public class Book
    {
        // creates an Id value automatically
        [Key]
        public int Id { get; set; }           // tyep prop(property) and tab twice

        [Required]  //can not be NULL
        public string Name { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; } 

    }
}
