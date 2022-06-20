using backendv3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace backendv3.Data.Repositories {
    public class UserRepo : System.Data.Entity.DbSet<User>, IUserRepo, IDisposable {
        private ApplicationDbContext _context;

        public void Save() => _context.SaveChanges();

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

        public ObservableCollection<User> Local => throw new NotImplementedException();

        public Type ElementType => throw new NotImplementedException();

        public Expression Expression => throw new NotImplementedException();

        public IQueryProvider Provider => throw new NotImplementedException();

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
