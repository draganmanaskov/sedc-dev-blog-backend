using DevBlog.Dtos.Stars;

namespace DevBlog.Services.Interfaces
{
    public interface IStarService
    {
        double CreateStar(CreateStarDto createStarDto, int index);
        double UpdateStar(UpdateStarDto updateStarDto, int index);
        bool CheckIfStarExists(int postId, int userId);
    }
}
