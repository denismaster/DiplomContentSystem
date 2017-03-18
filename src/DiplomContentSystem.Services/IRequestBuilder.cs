using DiplomContentSystem.Core;

namespace DiplomContentSystem.Services
{
    public interface IQueryBuilder<T> where T : class, IEntity
    {
        IQueryBuilder<T> UseDto(Dto.Request requestDto);
        IQueryBuilder<T> UseFilters();
        IQueryBuilder<T> UsePaging();
        IQueryBuilder<T> UsePaging(int page, int pageSize);
        IQueryBuilder<T> UseSortings(string defaultSorting);
        Query<T> Build();
    }
}