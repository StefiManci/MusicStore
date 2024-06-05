using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicStore.Models
{
    public class Order
    {
        /// <summary>
        /// Gets or Sets the Order Id
        /// </summary>
        [BindNever]
        public int Id { get; set; }
        /// <summary>
        /// Gets or Sets the Order IEnumerable Lines
        /// </summary>
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }
        /// <summary>
        /// Gets or Sets the Order Name
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Gets or Sets the Order Line 1
        /// </summary>
        [Required]
        public string Line1 { get; set; }
        /// <summary>
        /// Gets or Sets the Order Line 2
        /// </summary>
        [Required]
        public string Line2 { get; set; }
        /// <summary>
        /// Gets or Sets the Order Line 3
        /// </summary>
        [Required]
        public string Line3 { get; set; }
        /// <summary>
        /// Gets or Sets the Order Country
        /// </summary>
        [Required]
        public string Country { get; set; }
        /// <summary>
        /// Gets or Sets the Order City
        /// </summary>
        [Required]
        public string City { get; set; }
        /// <summary>
        /// Gets or Sets the Order State
        /// </summary>
        [Required]
        public string State { get; set; }
        /// <summary>
        /// Gets or Sets the Order Zip
        /// </summary>
        [Required]
        public string Zip {  get; set; }

    }
}
