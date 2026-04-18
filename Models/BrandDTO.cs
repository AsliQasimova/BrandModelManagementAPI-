using System.Runtime.Serialization;

namespace PhoneApp.Models
{
    public class BrandDTO
    {
        [DataMember(Name = "Name", Order = 0)]
        public string Name { get; set; }

    }
}
