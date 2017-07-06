using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace First_Application.Models
{
    public class PersonInfo
    {
        public int ID { get; set; }     
        public String firstName { get; set; }
        public String surname { get; set; }

        [Display(Name = "DOB")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

    }

    public class PersonDBContext : DbContext
    {
        public DbSet<PersonInfo> PersonInfo { get; set; }
    }
}