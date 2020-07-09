namespace MyWebSite.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Role")]
    public partial class Role
    {
        [StringLength(20)]
        public string ID { get; set; }

        [StringLength(20)]
        public string Name { get; set; }
    }
}
