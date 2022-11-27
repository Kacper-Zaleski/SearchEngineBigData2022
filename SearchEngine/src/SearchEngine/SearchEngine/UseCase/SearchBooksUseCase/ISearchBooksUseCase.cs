using SearchEngine.Models.Dto;

namespace SearchEngine.UseCase.SearchBooksUseCase
{
    public interface ISearchBooksUseSace
    {
        public Task<FindBookResponse> FindBooks(FindBookRequest request);
    }
}
