//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_KUTUPHANE.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TBLPERSONEL
    {
        public byte ID { get; set; }

        [Required(ErrorMessage = "Personel Ad� Bo� Ge�ilemez.")]
        public string PERSONEL { get; set; }
    }
}
