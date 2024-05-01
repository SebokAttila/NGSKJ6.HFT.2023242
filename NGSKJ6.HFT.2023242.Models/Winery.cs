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
    public class Winery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WineryId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Wine> Wines { get; set; }
        public Winery()
        {
            Wines = new HashSet<Wine>();
        }
    }
}
