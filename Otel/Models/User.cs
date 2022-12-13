using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Otel.Models
{
   
        public class User
        {
            [Required] //attribute = nitelik, özellik -- ctrl+. ya basıp kütüphane ekledik
            public string Username { get; set; } //username boş geçilmesin demek
            [Required] //password un özelliği (kolonları bu özelliği veriyoruz) 
            [DataType(DataType.Password)] //password un gizli olması demek 
            public string Password1 { get; set; }
        }
    
}