using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3_api.Models
{
    public class Product
    {
        //[Key()]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Colors { get; set; }
        [Range(1, 10)]
        public int SmellLevel { get; set; }
        public bool IsArtificial { get; set; }
    }
}
