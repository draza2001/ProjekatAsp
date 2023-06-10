using FluentValidation;
using ProjekatASP.Application.Commands.CommentCommands;
using ProjekatASP.Application.DataTransfer;
using ProjekatASP.Application.Exceptions;
using ProjekatASP.DataAccess.Configuration;
using ProjekatASP.Domain;
using ProjekatASP.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Implementation.Commands.EfCommentCommads
{
    public class EfUpdateCommentCommand : IUpdateCommentCommand
    {
        private readonly Context context;
        private readonly CreateCommentValidator validator;

        public EfUpdateCommentCommand(Context context, CreateCommentValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public int Id => 18;

        public string Name => "Update Comment";

        public void Execute(CommentDTO request, int id)
        {
            var comment = context.Comments.Find(id);
            if (comment == null)
            {
                throw new EntityNotFoundException(id, typeof(Comment));
            }
            validator.ValidateAndThrow(request);

            comment.Text = request.Text;
            comment.ModifiedAt = DateTime.Now;
            context.SaveChanges();
        }
    }
}
