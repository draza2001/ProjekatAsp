using FluentValidation;
using ProjekatASP.Application.Commands.CommentCommands;
using ProjekatASP.Application.DataTransfer;
using ProjekatASP.Application.Util;
using ProjekatASP.DataAccess.Configuration;
using ProjekatASP.Domain;
using ProjekatASP.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Implementation.Commands.EfCommentCommads
{
    public class EfCreateCommentCommand:ICreateCommentCommand
    {
        private readonly Context context;
        private readonly IApplicationActor actor;
        private readonly CreateCommentValidator validator;

        public EfCreateCommentCommand(Context context, IApplicationActor actor, CreateCommentValidator validator)
        {
            this.context = context;
            this.actor = actor;
            this.validator = validator;
        }

        public int Id => 17;

        public string Name => "Create comment";

        public void Execute(CommentDTO request)
        {
            validator.ValidateAndThrow(request);
            var comment = new Comment
            {
                Text = request.Text,
                BlogId =request.BlogId,
                UserId = actor.Id
            };
            context.Comments.Add(comment);
            context.SaveChanges();
        }
    }
}
