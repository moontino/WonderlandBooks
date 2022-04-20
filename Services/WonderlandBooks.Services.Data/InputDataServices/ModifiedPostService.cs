namespace WonderlandBooks.Services.Data.InputDataServices
{
    using System.Threading.Tasks;

    using WonderlandBooks.Data.Common.Repositories;
    using WonderlandBooks.Data.Models;
    using WonderlandBooks.Web.ViewModels.Posts;

    public class ModifiedPostService : IModifiedPostService
    {
        private readonly IDeletableEntityRepository<Post> postRepository;

        public ModifiedPostService(IDeletableEntityRepository<Post> postRepository)
        {
            this.postRepository = postRepository;
        }

        public async Task CreateAsync(PostCreateInputModel input, string userId)
        {
            var post = new Post
            {
                Title = input.Title,
                Content = input.Content,
                GenreId = input.GenreId,
                UserId = userId,
            };

            await this.postRepository.AddAsync(post);
            await this.postRepository.SaveChangesAsync();
        }
    }
}
