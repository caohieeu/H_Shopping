using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H_Shopping.Models
{
    [Table("LaptopSpecification")]
    public class LaptopSpecification
    {
        [Key]
        public int Id { get; set; }
        public string Cpu { get; set; }
        public string Vga { get; set; }
        public string Ram { get; set; }
        public string Ssd { get; set; }
        public string Monitor { get; set; }
        public string Os { get; set; }
        public string Lan { get; set; }
        public string WirelessLan { get; set; }
        public string ConnectionPort { get; set; }
        public string KeyBoard { get; set; }
        public string Pin { get; set; }
        public string Weight { get; set; }
    }
}
