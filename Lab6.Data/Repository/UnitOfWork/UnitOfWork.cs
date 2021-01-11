using Lab6.Data.DB.UsersSourceModelEFCF.DAO;
using Lab6.Data.Repository.Rooms;
using Lab6.Data.Repository.Users;
using System;

namespace Lab6.Data.Repository.UnitOfWork
{
    class UnitOfWork : IDisposable
    {

        private readonly UsersCFDAO dao = new UsersCFDAO();

        private IUsersRepository _usersRepository;
        private IRoomsRepository _roomsRepository;

        public IUsersRepository UsersRepository
        {
            get
            {
                if (_usersRepository == null)
                {
                    _usersRepository = new UsersRepository(dao);
                }
                return _usersRepository;
            }
        }

        public IRoomsRepository RoomsRepository
        {
            get
            {
                if (_roomsRepository == null)
                {
                    _roomsRepository = new RoomRepository(dao);
                }
                return _roomsRepository;
            }
        }

        private bool isDisposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (isDisposed) return;
            if (disposing)
            {
                dao.Dispose();
            }
            isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
