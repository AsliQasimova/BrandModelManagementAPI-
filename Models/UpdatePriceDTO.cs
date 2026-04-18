using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace PhoneApp.Models
{
    public class UpdatePriceDTO
    {
        [DataMember(Order = 0)]
        [Required]
        public decimal NewPrice { get; set; }
    }
}
