using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Erasmus.Models
{
    public class Student
    {
        public int ID { get; set; }
        [Display(Name = "Akademska godina")]
        public string AkademskaGodina { get; set; }
        [Display(Name = "Ljetni rok")]
        public bool RokLjetni { get; set; }
        [Display(Name = "Zimski rok")]
        public bool RokZimski { get; set; }
        [Display(Name = "Studijski program")]
        public string StudijskiProgram { get; set; }
        [Display(Name = "Područje studija")]
        public string PodrucjeStudija { get; set; }
        [Display(Name = "Puno ime studenta")]
        public string PunoImeStudenta { get; set; }
        [Display(Name = "Datum rođenja")]
        [DataType(DataType.Date)]
        public DateTime DatumRodenja { get; set; }
        public string Spol { get; set; }
        [Display(Name = "Mjesto rođenja")]
        public string MjestoRodenja { get; set; }
        [Display(Name = "Zemlja rođenja")]
        public Country ZemljaRodenja { get; set; }
        public string Nacionalnost { get; set; }
        public string OIB { get; set; }
        [Display(Name = "Sveučilište/institucija")]
        public string SveucilisteInstitucija { get; set; }
        [Display(Name = "Škola/odjel")]
        public string SkolaOdjel { get; set; }
        [Display(Name = "Grad studija")]
        public string GradStudija { get; set; }
        [Display(Name = "Zemlja studija")]
        public Country ZemljaStudija { get; set; }
        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }
        [Display(Name = "Slika")]
        public byte[] SlikaDatoteka { get; set; }

        public string MimeTypeSlika { get; set; }

        public virtual ICollection<Kolegij> Kolegijs { get; set; }
    }
   
    // ZEMLJE
    public enum Country
    {
        [Display(Name = "United States of America")]
        UnitedStatesofAmerica,
        Afghanistan,
        Albania,
        Algeria,
        Andorra,
        Angola,
        [Display(Name = "Antigua & Barbuda")]
        AntiguaDeps,
        Argentina,
        Armenia,
        Australia,
        Austria,
        Azerbaijan,
        Bahamas,
        Bahrain,
        Bangladesh,
        Barbados,
        Belarus,
        Belgium,
        Belize,
        Benin,
        Bhutan,
        Bolivia,
        [Display(Name = "Bosnia & Herzegovina")]
        BosniaHerzegovina,
        Botswana,
        Brazil, Brunei, Bulgaria, Burkina, Burma, Burundi, Cambodia, Cameroon, Canada,
        [Display(Name = "Cape Verde")]
        CapeVerde,
        [Display(Name = "Central African Republic")]
        CentralAfricanRep,
        Chad, Chile,
        [Display(Name = "People's Republic of China")]
        PeoplesRepublicofChina,
        [Display(Name = "Taiwan (Republic of China")]
        RepublicofChina,
        Colombia, Comoros,
        [Display(Name = "Democratic Republic of The Congo")]
        DemocraticRepublicoftheCongo,
        [Display(Name = "Costa Rica")]
        CostaRica,
        Croatia, Cuba, Cyprus,
        [Display(Name = "Czech Republic")]
        CzechRepublic,
        Danzig, Denmark, Djibouti, Dominica,
        [Display(Name = "Dominican Republic")]
        DominicanRepublic,
        [Display(Name = "East Timor")]
        EastTimor,
        Ecuador, Egypt,
        [Display(Name = "El Salvador")]
        ElSalvador,
        [Display(Name = "Equatorial Guinea")]
        EquatorialGuinea,
        Eritrea, Estonia, Ethiopia, Fiji, Finland, France, Gabon,
        [Display(Name = "Gaza Strip")]
        GazaStrip,
        [Display(Name = "The Gambia")]
        TheGambia,
        Georgia, Germany, Ghana, Greece, Grenada, Guatemala, Guinea,
        [Display(Name = "Guinea Bissau")]
        GuineaBissau,
        Guyana, Haiti,
        Honduras, Hungary, Iceland, India, Indonesia, Iran, Iraq,
        [Display(Name = "Republic of Ireland")]
        RepublicofIreland,
        Israel, Italy,
        [Display(Name = "Ivory Coast")]
        IvoryCoast,
        Jamaica, Japan, Jonathanland, Jordan, Kazakhstan, Kenya, Kiribati,
        [Display(Name = "North Korea")]
        NorthKorea,
        [Display(Name = "South Korea")]
        SouthKorea,
        Kosovo, Kuwait, Kyrgyzstan, Laos, Latvia, Lebanon, Lesotho, Liberia, Libya, Liechtenstein, Lithuania, Luxembourg, Macedonia, Madagascar, Malawi, Malaysia, Maldives, Mali, Malta,
        [Display(Name = "Marshall Islands")]
        MarshallIslands,
        Mauritania, Mauritius, Mexico, Micronesia, Moldova, Monaco, Mongolia, Montenegro, Morocco,
        [Display(Name = "Mount Athos")]
        MountAthos,
        Mozambique, Namibia, Nauru, Nepal, Newfoundland, Netherlands,
        [Display(Name = "New Zealand")]
        NewZealand,
        Nicaragua, Niger, Nigeria, Norway, Oman,
        Pakistan, Palau, Panama,
        [Display(Name = "Republic of Turkey")]
        RepublicofTurkey,
        [Display(Name = "Papua New Guinea")]
        PapuaNewGuinea, Paraguay, Peru, Philippines, Poland, Portugal, Prussia, Qatar, Romania, Rome,
        [Display(Name = "Russian Federation")]
        RussianFederation,
        Rwanda,
        [Display(Name = "St. Kitts & Nevis")]
        StKittsandNevis,
        [Display(Name = "St. Lucia")]
        StLucia,
        [Display(Name = "St. Vincent & the Grenadines")]
        SaintVincentandtheGrenadines,
        Samoa,
        [Display(Name = "San Marino")]
        SanMarino,
        [Display(Name = "Sao Tome & Principe")]
        SaoTomeandPrincipe,
        [Display(Name = "Saudi Arabia")]
        SaudiArabia,
        Senegal, Serbia, Seychelles,
        [Display(Name = "Sierra Leone")]
        SierraLeone,
        Singapore, Slovakia, Slovenia,
        [Display(Name = "Solomon Islands")]
        SolomonIslands,
        Somalia,
        [Display(Name = "South Africa")]
        SouthAfrica, Spain,
        [Display(Name = "Sri Lanka")]
        SriLanka,
        Sudan, Suriname, Swaziland, Sweden, Switzerland, Syria, Tajikistan, Tanzania, Thailand, Togo, Tonga,
        [Display(Name = "Trinidad & Tobago")]
        TrinidadandTobago,
        Tunisia, Turkey, Turkmenistan, Tuvalu, Uganda, Ukraine,
        [Display(Name = "United Arab Emirates")]
        UnitedArabEmirates,
        [Display(Name = "United Kingdom")]
        UnitedKingdom,
        Uruguay, Uzbekistan, Vanuatu,
        [Display(Name = "Vatican City")]
        VaticanCity,
        Venezuela, Vietnam, Yemen, Zambia, Zimbabwe
    }


    // DB CONTEXT

    public class StudentDbContext : DbContext
    {
        public StudentDbContext() : base("name=StudentDbContext")
        { }
        public DbSet<Student> Students { get; set; }
    }
}
