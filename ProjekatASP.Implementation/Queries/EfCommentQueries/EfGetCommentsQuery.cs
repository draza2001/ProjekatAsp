using ProjekatASP.Application.DataTransfer;
using ProjekatASP.Application.Exceptions;
using ProjekatASP.Application.Queries.CommentQuery;
using ProjekatASP.DataAccess.Configuration;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Implementation.Queries.EfCommentQueries
{
    public class EfGetCommentsQuery : IGetCommentsQuery
    {
        private readonly Context context;

        public EfGetCommentsQuery(Context context)
        {
            this.context = context;
        }

        public int Id => 16;

        public string Name => "Get comments";

        public CommentDTO Execute(int id)
        {
            var comment = context.Comments.Find(id);

            if (comment == null)
            {
                throw new EntityNotFoundException(id, typeof(Comment));
            }

            var blog = context.Blogs.Find(comment.BlogId);
            var blogDto = new BlogDTO
            {
                Id = blog.Id,
                Subject = blog.Subject
            };

            var user = context.Users.Find(comment.UserId);
            var userDto = new UserDTO
            {
                UserName = user.UserName,
                
            };

            var result = new CommentDTO
            {
               Text=comment.Text,
               UserName=userDto.UserName,
               BlogId=blogDto.Id,
               Name=blogDto.Subject
              
            };
            return result;
        }
    }
}
