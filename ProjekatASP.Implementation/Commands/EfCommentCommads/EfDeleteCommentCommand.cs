using ProjekatASP.Application.Commands.CommentCommands;
using ProjekatASP.Application.Exceptions;
using ProjekatASP.DataAccess.Configuration;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Implementation.Commands.EfCommentCommads
{
    public class EfDeleteCommentCommand : IDeleteCommentCommand
    {
        private readonly Context context;

        public EfDeleteCommentCommand(Context context)
        {
            this.context = context;
        }

        public int Id => 19;

        public string Name => "Delete comment";

        public void Execute(int id)
        {
            var comment = context.Comments.Find(id);
            if (comment == null)
            {
                throw new EntityNotFoundException(id, typeof(Comment));
            }

            if (comment.IsDeleted == true)
            {
                throw new DeletedException(id, typeof(Comment));
            }

            comment.DeletedAt = DateTime.Now;
            comment.IsActive = false;
            comment.IsDeleted = true;
            context.SaveChanges();
        }
    }
}
