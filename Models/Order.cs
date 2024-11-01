﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        [Required(ErrorMessage ="Please enter your Name")]
        public string Name { get; set; }
        /// <summary>
        /// Gets or Sets the Shipped State of the Order
        /// </summary>
        [BindNever]
        public bool Shipped { get; set; }
        /// <summary>
        /// Gets or Sets the Order Line 1
        /// </summary>
        [Required(ErrorMessage = "Please enter your First-address")]
        public string Line1 { get; set; }
        /// <summary>
        /// Gets or Sets the Order Line 2
        /// </summary>
        [Required(ErrorMessage = "Please enter your Second-address")]
        public string Line2 { get; set; }
        /// <summary>
        /// Gets or Sets the Order Line 3
        /// </summary>
        [Required(ErrorMessage = "Please enter your Third-address")]
        public string Line3 { get; set; }
        /// <summary>
        /// Gets or Sets the Order Country
        /// </summary>
        [Required(ErrorMessage = "Please enter your Country")]
        public string Country { get; set; }
        /// <summary>
        /// Gets or Sets the Order City
        /// </summary>
        [Required(ErrorMessage = "Please enter your City")]
        public string City { get; set; }
        /// <summary>
        /// Gets or Sets the Order State
        /// </summary>
        [Required(ErrorMessage = "Please enter your State")]
        public string State { get; set; }
        /// <summary>
        /// Gets or Sets the Order Zip
        /// </summary>
        [Required(ErrorMessage = "Please enter your Zip")]
        public string Zip {  get; set; }

    }
}
