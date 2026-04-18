using System.Runtime.Serialization;

namespace PhoneApp.Models
{
    public class FeatureDTO
    {
        [DataMember(Name = "ID", Order = 0)]
        public int Id { get; set; }

        [DataMember(Name = "ModelID", Order = 1)]
        public int ModelID { get; set; }

        [DataMember(Name = "Camera", Order = 2)]
        public string Camera { get; set; }

        [DataMember(Name = "Storage", Order = 3)]
        public string Storage { get; set; }

        [DataMember(Name = "Ram", Order = 4)]
        public string Ram { get; set; }
    }
}
