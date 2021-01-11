using System.Data.Entity;

namespace Lab6.Data.DB.UsersSourceModelEFCF.DAO
{
    class UsersCFDAO : DbContext
    {

        public UsersCFDAO() : base("KpzLab6EntitiesCF")
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<RoomBooking> RoomBookings { get; set; }

    }
}
