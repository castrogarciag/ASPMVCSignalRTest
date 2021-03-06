﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPMVCSignalRTest.Models
{
    public class ProductEntry
    {
        [Key]
        public int Id { get; set; }
        [Key]
        public ProductList List { get; set; }
        public virtual Product Product { get; set; }
        public int Amount { get; set; }
        public string Comments { get; set; }

    }
}