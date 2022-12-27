using DataArchiver.Models;

namespace DataArchiver.UseCase
{
    public interface IArchiveData
    {
        Task<ArchiveDataResponse> ArchiveDataUseCase(List<Book> books);
    }
}
