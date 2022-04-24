namespace WonderlandBooks.Services.Data.InputDataServices
{
    using System.Threading.Tasks;

    using WonderlandBooks.Data.Common.Repositories;
    using WonderlandBooks.Data.Models;

    public class ModifiedCommentService : IModifiedCommentService
    {
        private readonly IDeletableEntityRepository<Comment> commentRepository;

        public ModifiedCommentService(IDeletableEntityRepository<Comment> commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public async Task CreateAsync(int postId, string userId, string content, int? parentId = null)
        {
            var comment = new Comment
            {
                Content = content,
                ParentId = parentId,
                PostId = postId,
                UserId = userId,
            };

            await this.commentRepository.AddAsync(comment);
            await this.commentRepository.SaveChangesAsync();
        }
    }
}
