using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PhoneApp.Entities
{
    public class Feature
    {
        [Key]
        public int ID { get; set; }
        public string Camera { get; set; }
        public string Storage { get; set; }
        public string Ram { get; set; }
        public int ModelID { get; set; }

        public bool IsDeleted { get; set; }
    }
}
