using backendv3.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace backendv3.Data.Repositories {
    public class UserRepo : IUserRepo, IDisposable {
        private ApplicationDbContext _context;


        public UserRepo(ApplicationDbContext context) {
            _context = context;
        }

        public User GetUserById(Guid userId) {
            return _context.User.FirstOrDefault(u => u.Id == userId);
        }

        public IEnumerable<User> GetAllUsersById(IEnumerable<Guid> userIds) {
            return _context.User.Where(u => userIds.Any(id => id == u.Id));
        }

        public IEnumerable<User> AllUsers() {
            return _context.User;
        }

        #region disposer
        private bool disposedValue;
        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                    _context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UserRepo()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose() {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion disposer
    }
}
