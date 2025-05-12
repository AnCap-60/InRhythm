namespace InRhythmServer.Services;

public interface IPaginatedService<T> : IService<T>
{
    Task<List<T>> GetPage(int pageNumber, int pageSize);
}