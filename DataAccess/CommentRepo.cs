﻿using NewModels;
using Microsoft.EntityFrameworkCore;
using CustomExceptions;

namespace DataAccess
{
    public class CommentRepo : ICommentRepo
    {
        private readonly InsuranceDbContext _dbContext;
        public CommentRepo(InsuranceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commentToAdd"></param>
        /// <returns></returns>
        /// <exception cref="TicketNotAvailableException"></exception>
        public Comment CreateComment(Comment commentToAdd)
        {
            _dbContext.Comments.Add(commentToAdd);
            Finish();
            return commentToAdd ?? throw new CommentNotAvailableException();
        }

        public bool DeleteComment(int commentIDToDelete)
        {
            Comment? commentToDelete = _dbContext.Comments.FirstOrDefault(r=>r.commentID==commentIDToDelete);
            if (commentToDelete != null)
            {
                _dbContext.Entry(commentToDelete).State = EntityState.Deleted;
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Comment> GetAllComments()
        {
            return _dbContext.Comments.AsNoTracking().ToList() ?? new List<Comment>();
        }

        public Comment GetCommentByID(int commentID)
        {
            return _dbContext.Comments.AsNoTracking().FirstOrDefault(p => p.commentID == commentID)??throw new CommentNotAvailableException();
        }

        public List<Comment> GetCommentByPost(int postID)
        {
            return _dbContext.Comments.AsNoTracking().Where(p => p.messageID== postID).ToList();
        }

        public List<Comment> GetCommentByUser(int userID)
        {
            return _dbContext.Comments.AsNoTracking().Where(p => p.userID == userID).ToList(); 
        }

        public Comment UpdateComment(Comment CommentToUpdate)
        {
            _dbContext.Comments.Update(CommentToUpdate);
            Finish();
            return CommentToUpdate ?? throw new CommentNotAvailableException();
        }
        protected void Finish()
        {
            _dbContext.SaveChanges();
            _dbContext.ChangeTracker.Clear();
        }
    }
}