//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kilidsite.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Agancy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Agancy()
        {
            this.Advertises = new HashSet<Advertise>();
        }
    
        public int ID { get; set; }
        public string AgancyName { get; set; }
        public string AcancyPhone { get; set; }
        public string City { get; set; }
        public Nullable<int> NumberofEmployees { get; set; }
        public string ManagerName { get; set; }
        public string ManagerPhoneNumber { get; set; }
        public string Password { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Advertise> Advertises { get; set; }
    }
}