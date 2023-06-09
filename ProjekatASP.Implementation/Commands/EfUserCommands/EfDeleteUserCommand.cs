using ProjekatASP.Application.Commands.Usercommands;
using ProjekatASP.Application.Exceptions;
using ProjekatASP.Application.Util;
using ProjekatASP.DataAccess.Configuration;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Implementation.Commands.EfUserCommands
{
    public class EfDeleteUserCommand : IDeleteUserCommand
    {
        private readonly Context _context;
        private readonly IApplicationActor _actor;

        public EfDeleteUserCommand(Context ontext, IApplicationActor actor)
        {
            _context = ontext;
            _actor = actor;
        }

        public int Id => 5;

        public string Name => "Delete user";

        public void Execute(int id)
        {
            var user = _context.Users.Find(id);
            if (user.Id == _actor.Id) 
            {
                throw new DeleteYourselfException(id, typeof(User));
            }
            if (user == null)
            {
                throw new EntityNotFoundException(id, typeof(User));
            }
            if (user.IsDeleted == true)
            {
                throw new DeletedException(id, typeof(User));
            }
            user.IsActive = false;
            user.IsDeleted = true;
            user.DeletedAt = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
