using FluentValidation;
using ProjekatASP.Application.Commands.Usercommands;
using ProjekatASP.Application.DataTransfer;
using ProjekatASP.Application.Exceptions;
using ProjekatASP.DataAccess.Configuration;
using ProjekatASP.Domain;
using ProjekatASP.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Implementation.Commands.EfUserCommands
{
    public class EfUpdateUserCommand : IUpdateUserCommand
    {
        private readonly Context _context;
        private readonly UpdateUserValidator _validator;

        public EfUpdateUserCommand(Context context, UpdateUserValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 4;

        public string Name => "Update user";

        public void Execute(UserDTO request, int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                throw new EntityNotFoundException(id, typeof(User));
            }
            _validator.ValidateAndThrow(request);

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.UserName = request.UserName;
            user.Email = request.Email;
            user.ModifiedAt = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
