using DevBlog.Dtos.Stars;

namespace DevBlog.Services.Interfaces
{
    public interface IStarService
    {
        double CreateStar(CreateStarDto createStarDto);
        double UpdateStar(UpdateStarDto updateStarDto);
        bool CheckIfStarExists(int postId, int userId);
    }
}
