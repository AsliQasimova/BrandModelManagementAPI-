using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace PhoneApp.Models
{
    [DataContract(Name = "Model")]
    public class ModelDTO
    {
        [DataMember(Name = "ID", Order = 0)]
        public int Id { get; set; }

        [DataMember(Name = "Name", Order = 1)]
        public string Name { get; set; }

        [DataMember(Name = "Price", Order = 2)]
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public decimal Price { get; set; }

        [DataMember(Name = "Quantity", Order = 3)]
        public int Quantity { get; set; }

        [DataMember(Name = "BrandID", Order = 4)]
        public int BrandID { get; set; }


    }
}
