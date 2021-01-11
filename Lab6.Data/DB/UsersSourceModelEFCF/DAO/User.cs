using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab6.Data.DB.UsersSourceModelEFCF.DAO
{
    class User
    {
        public User()
        {
            RoomBookings = new HashSet<RoomBooking>();
        }

        public int Id { get; set; }

        [Column(TypeName="VARCHAR")]
        [StringLength(255)]
        public string Name { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string Surname { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string Email { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string Type { get; set; }


        public virtual ICollection<RoomBooking> RoomBookings { get; set; }
    }
}
