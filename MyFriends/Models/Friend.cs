using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace MyFriends.Models
{
    public class Friend
    {
        public int Id { get; set; }

        [Required, MinLength(1), MaxLength(50) ]
        public string Name { get; set; }

        [Required, Range(1,150)]
        public int Age { get; set; }
    }
}