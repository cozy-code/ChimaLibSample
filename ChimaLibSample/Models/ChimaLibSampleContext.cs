using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ChimaLibSample.Models
{
    public class ChimaLibSampleContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
    }
}