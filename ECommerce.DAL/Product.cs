//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ECommerce.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.Image = new HashSet<Image>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public bool IsActive { get; set; }
        public DateTime ArriveDate { get; set; }
        public double Pricre { get; set; }
        public int CategoryID { get; set; }
        public int BrandID { get; set; }
        public int SupplierID { get; set; }
    
        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Image> Image { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
