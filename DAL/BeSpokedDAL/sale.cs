//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BeSpokedDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class sale
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public int sales_person_id { get; set; }
        public int customer_id { get; set; }
        public System.DateTime sales_date { get; set; }
    
        public virtual customer customer { get; set; }
        public virtual product product { get; set; }
        public virtual sales_person sales_person { get; set; }
    }
}
