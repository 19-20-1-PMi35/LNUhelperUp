using LNUhelperUp.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNUhelperUp.UnitOfWorkPattern
{
    public interface IUnitOfWork: IDisposable
    {
        IAnnouncementRepository AnnouncementRepository { get; }
        ICommentRepository CommentRepository { get; }
        IEventRepository EventRepository { get; }
        IFacultyRepository FacultyRepository { get; }
        IRoleRepository RoleRepository { get; }
        IUserRepository UserRepository { get; }
        IImageRepository ImageRepository { get; }
        Task<int> Complete();
    }
}
