using GoodReadersClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoodReadersClone.Domain.Models;
public class PaginatedList<T>
{
    public List<T> Items { get; }
    public int PageIndex { get; }
    public int TotalPages { get; }
    public bool HasPreviousPage => PageIndex > 1;
    public bool HasNextPage => PageIndex < TotalPages;

    public PaginatedList(List<T> items, int pageIndex, int totalPages)
    {
        Items = items;
        PageIndex = pageIndex;
        TotalPages = totalPages;
    }

    public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> query, int pageIndex, int pageSize)
    {
        var items = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        var totalPages = (int)Math.Ceiling(await query.CountAsync() / (double)pageSize);

        return new PaginatedList<T>(items, pageIndex, totalPages);
    }
}
