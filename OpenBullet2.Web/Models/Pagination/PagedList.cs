﻿using Microsoft.EntityFrameworkCore;
using OpenBullet2.Core.Entities;

namespace OpenBullet2.Web.Models.Pagination;

/// <summary>
/// List with pagination features.
/// </summary>
public class PagedList<T>
{
    /// <summary>
    /// The list of items.
    /// </summary>
    public List<T> Items { get; private set; }

    /// <summary>
    /// The current page.
    /// </summary>
    public int PageNumber { get; set; }

    /// <summary>
    /// The total number of pages.
    /// </summary>
    public int TotalPages { get; set; }

    /// <summary>
    /// The page size.
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// The total number of items.
    /// </summary>
    public int TotalCount { get; set; }

    /// <summary></summary>
    public PagedList(IEnumerable<T> items, int totalCount, int pageNumber,
        int pageSize)
    {
        PageNumber = pageNumber;
        TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        PageSize = pageSize;
        TotalCount = totalCount;
        Items = items.ToList();
    }

    /// <summary>
    /// Creates a paged list from an <see cref="IQueryable{T}"/>, useful
    /// for DB calls to optimize the query.
    /// </summary>
    public static async Task<PagedList<TEntity>> CreateAsync<TEntity>(
        IQueryable<TEntity> source,
        int pageNumber, int pageSize) where TEntity : Entity
    {
        var count = await source.CountAsync();
        var items = await source
            .OrderBy(x => x.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize).ToListAsync();

        return new PagedList<TEntity>(items, count, pageNumber, pageSize);
    }
}
