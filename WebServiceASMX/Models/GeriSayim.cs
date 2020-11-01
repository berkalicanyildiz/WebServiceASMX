using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebServiceASMX.Models
{
    [Table("Geri_Sayimlar")]
    public class GeriSayim
    {
        [Key]
        public int GeriSayimID  { get; set; }
        [StringLength(150)]
        [Required]
        public string GeriSayim_Adi { get; set; }
        [Required]
        public DateTime Tarih { get; set; }
        [StringLength(50)]
        [Required]
        public string Resim_Url { get; set; }

    }
}