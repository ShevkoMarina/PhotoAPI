using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoAPI.Model
{
    [Table("photos")]
    public partial class Photo
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("date_created", TypeName = "date")]
        public DateTime DateCreated { get; set; } //?

        [Column("image_source", TypeName = "image")]
        public byte[] ImageSource { get; set; }

        [Column("id_user")]
        public int? UserId { get; set; }
    }
}
