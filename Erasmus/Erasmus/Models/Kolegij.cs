using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Erasmus.Models
{
    public class Kolegij
    {
        public int ID { get; set; }
        [Display(Name = "Naziv kolegija")]
        public string NazivKolegija { get; set; }
        [Display(Name = "Nositelj kolegija")]
        public string NositeljKolegija { get; set; }
        [Display(Name = "Puno ime studenta")]
        public int StudentID { get; set; }
        [Display(Name = "Redni broj roka")]
        public string RBrRoka { get; set; }
        [Display(Name = "Datum roka")]
        [DataType(DataType.Date)]
        public DateTime DatumRoka { get; set; }
        public Ocjena? Ocjena { get; set; }

        public virtual Student Students { get; set; }
    }
    public enum Ocjena
    {
        [Display(Name = "5")]
        A,
        [Display(Name = "4")]
        B,
        [Display(Name = "3")]
        C,
        [Display(Name = "2")]
        D,
        [Display(Name = "1")]
        F
    }

    public class KolegijDbContext : DbContext
    {
        public KolegijDbContext() : base("name=KolegijDbContext")
        { }
        public DbSet<Kolegij> Kolegijs { get; set; }

        public DbSet<Student> Students { get; set; }
    }
}
