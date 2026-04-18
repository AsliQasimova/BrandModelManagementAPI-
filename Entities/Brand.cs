using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace PhoneApp.Entities
{
    public class Brand
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<Model> Models { get; set; } = new List<Model>();
    }
}
