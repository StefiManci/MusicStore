using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MusicStore.Models;
namespace MusicStore.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }
        [BindNever]

        public ICollection<CartLine> Lines { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Line1 { get; set; }
        [Required]
        public string Line2 { get; set; }
        [Required]
        public string Line3 { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Zip {  get; set; }

    }
}
