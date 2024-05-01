using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NGSKJ6.HFT._2023242.Models
{
    public class Wine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WineId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Vintage { get; set; }
        public int Amount { get; set; }
        [ForeignKey(nameof(Winery))]
        public int WineryId { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Winery Winery { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Barrell> Barells { get; set; }

        public Wine()
        {
            this.Barells = new HashSet<Barrell>();
        }
    }
}
