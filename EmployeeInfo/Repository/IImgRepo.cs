namespace EmployeeInfo.Repository
{
    public interface IImgRepo
    {
        Task<string>Upload(IFormFile file);
    }
}
