using PhoneApp.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneApp.Entities
{
    public class Model
    {
        [Key]
        [Required]
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int BrandID { get; set; }

        public bool IsDeleted { get; set; }

        public Feature Feature { get; set; }

    }
}
