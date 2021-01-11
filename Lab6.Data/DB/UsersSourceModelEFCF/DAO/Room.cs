using System.Collections.Generic;

namespace Lab6.Data.DB.UsersSourceModelEFCF.DAO
{
    class Room
    {
        public Room()
        {
            RoomBookings = new HashSet<RoomBooking>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<RoomBooking> RoomBookings { get; set; }

    }
}
