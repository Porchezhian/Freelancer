//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace freelancer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class metaUser
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9])(?!.*\s).{8,15}$")]
        public string Password { get; set; }
        public string Type { get; set; }
        [Required]
        [Compare("Password")]
        public string Confirm { get; set; }
    }

    [MetadataType(typeof(metaUser))]
    public partial class tblUser
    {
        public int Id { get; set; }
        
        public string Username { get; set; }
       
        public string Password { get; set; }
        public string Type { get; set; }
        
        public string Confirm { get; set; }
    }
}