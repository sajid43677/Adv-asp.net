//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace zerohunger.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class request
    {
        public int id { get; set; }
        public double weight { get; set; }
        public System.DateTime validity { get; set; }
        public System.DateTime start { get; set; }
        public string status { get; set; }
        public int rid { get; set; }
        public int cid { get; set; }
    
        public virtual collector collector { get; set; }
        public virtual restrurant restrurant { get; set; }
    }
}