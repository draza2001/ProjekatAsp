
using FluentValidation;
using ProjekatASP.Application.Emails;
using ProjekatASP.Application.Commands;
using ProjekatASP.Application.DataTransfer;
using ProjekatASP.DataAccess.Configuration;
using ProjekatASP.Domain;
using ProjekatASP.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Implementation
{
    public class EfRegisterUserCommand : IRegisterUserCommand
    {
        private readonly Context  _context;
        private readonly CreateUserValidator _validator;
        private readonly IEmailSender _sender;

        public EfRegisterUserCommand(Context context, CreateUserValidator validator, IEmailSender sender)
        {
            _context = context;
            _validator = validator;
            _sender = sender;
        }

        public int Id => 12;

        public string Name => "User registration";

        public void Execute(RegisterDTO request)
        {
            _validator.ValidateAndThrow(request);

            HashSet<UserUseCase> usecases = new HashSet<UserUseCase>();
            foreach(var uucId in request.UseCaseId)
            {
                var userUseCase = new UserUseCase
                {
                    UserUseCaseId = uucId
                };
            }
            _context.Users.Add(new Domain.User
            {
                FirstName=request.FirstName,
                LastName=request.LstName,
                UserName=request.UserName,
                Password=request.Password,
                Email=request.Email,
                UserUseCases=usecases

            });
            _context.SaveChanges();
            _sender.Send(new SendEmailDTO
            {
                Content = "<h1>Successfully registrated</h1>",
               SendTo = request.Email,
               Subject = "Registration"
            });
        }
    }
}
