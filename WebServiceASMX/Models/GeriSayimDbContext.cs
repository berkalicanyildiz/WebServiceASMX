using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebServiceASMX.Models
{
    public class GeriSayimDbContext:DbContext
    {
        public GeriSayimDbContext():base("name=GeriSayimDbContext")
        {
            base.Configuration.LazyLoadingEnabled = false;
           
        }
        public virtual DbSet<GeriSayim> Geri_Sayimlar { get; set; }
    }
}