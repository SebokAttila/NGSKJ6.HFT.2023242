using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NGSKJ6.HFT._2023242.Models
{
    public enum Types
    {
        Barrique,
        Lager
    }
    public class Barrell
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BarrelId { get; set; }
        public int Capacity { get; set; }
        public string Material { get; set; }
        public int NumberOfUses { get; set; }
        public Types Type { get; set; }
        [ForeignKey("Wine")]
        public int WineId { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Wine Wine { get; set; }
    }
}
