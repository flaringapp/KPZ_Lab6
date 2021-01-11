using Lab6.Data.DB.UsersSourceModelEFCF.DAO;
using System.ComponentModel.DataAnnotations;

namespace Lab6.Data.DB.UsersSourceModelEFCF
{
    class RoomBooking
    {

        [Key]
        public int BookingId { get; set; }

        public int UserId { get; set; }

        public int RoomId { get; set; }

        public virtual Room Room { get; set; }
        public virtual User User { get; set; }
    }
}
