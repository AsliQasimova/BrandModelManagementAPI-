using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace PhoneApp.Models
{
    public class PostModelDTO
    {
        [Required]
        [DataMember(Name = "Name", Order = 0)]
        public string Name { get; set; }

        [Required]
        [DataMember(Name = "Price", Order = 1)]
        public decimal Price { get; set; }

        [Required]
        [DataMember(Name = "Quantity", Order =2)]
        public int Quantity { get; set; }

        [Required]
        [DataMember(Name = "BrandID", Order =3)]
        public int BrandID { get; set; }
    }
}
