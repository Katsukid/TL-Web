namespace MyWebSite.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Permiss")]
    public partial class Permiss
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string UserGroupID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string RoldeID { get; set; }
    }
}
