namespace Lab6
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Note")]
    public partial class Note
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(10)]
        public string subj { get; set; }

        [Column("note")]
        public int note1 { get; set; }

        public int? student_id { get; set; }

        public virtual Student Student { get; set; }
    }
}
