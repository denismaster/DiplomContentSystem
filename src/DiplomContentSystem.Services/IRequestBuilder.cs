using DiplomContentSystem.Core;

namespace DiplomContentSystem.Services
{
    public interface IRequestBuilder<T> where T : class, IEntity
    {
        RequestBuilder<T> UseDto(Dto.Request requestDto);
        RequestBuilder<T> UseFilters();
        RequestBuilder<T> UsePaging();
        RequestBuilder<T> UsePaging(int page, int pageSize);
        RequestBuilder<T> UseSortings(string defaultSorting);
        Request<T> Build();
    }
}