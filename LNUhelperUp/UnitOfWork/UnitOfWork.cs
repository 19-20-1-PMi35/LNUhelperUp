using LNUhelperUp.Models;
using LNUhelperUp.Repositories.ImplementedRepositories;
using LNUhelperUp.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNUhelperUp.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork 
    {
        private readonly LNUhelperContext _context;
        private bool _disposed = false;

        private IAnnouncementRepository _announcementRepository;
        private ICommentRepository _commentRepository;
        private IEventRepository _eventRepository;
        private IFacultyRepository _facultyRepository;
        private IRoleRepository _roleRepository;
        private IUserRepository _userRepository;

        public IAnnouncementRepository AnnouncementRepository
        {
            get
            {
                if (_announcementRepository == null)
                    _announcementRepository = new AnnouncementRepository(_context);

                return _announcementRepository;
            }
        }

        public ICommentRepository CommentRepository
        {
            get
            {
                if (_commentRepository == null)
                    _commentRepository = new CommentRepository(_context);

                return _commentRepository;
            }
        }
        public IEventRepository EventRepository
        {
            get
            {
                if (_eventRepository == null)
                    _eventRepository = new EventRepository(_context);

                return _eventRepository;
            }
        }
        public IFacultyRepository FacultyRepository
        {
            get
            {
                if (_facultyRepository == null)
                    _facultyRepository = new FacultyRepository(_context);

                return _facultyRepository;
            }
        }
        public IRoleRepository RoleRepository
        {
            get
            {
                if (_roleRepository == null)
                    _roleRepository = new RoleRepository(_context);

                return _roleRepository;
            }
        }
        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_context);

                return _userRepository;
            }
        }

        public UnitOfWork(LNUhelperContext context)
        {
            _context = context;
        }


        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this._disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
