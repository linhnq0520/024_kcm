using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Jits.Neptune.Core;
using Jits.Neptune.Web.CMS.LogicOptimal9.JsonClass;
using Jits.Neptune.Web.Framework.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Common;

/// <summary>
/// The extensions class
/// </summary>

internal static class O9Extensions
{
    /// <summary>
    /// Datas the list to paged list using the specified j token
    /// </summary>
    /// <typeparam name="T">The </typeparam>
    /// <param name="jToken">The token</param>
    /// <param name="pageIndex">The page index</param>
    /// <param name="pageSize">The page size</param>
    /// <param name="getOnlyTotalCount">The get only total count</param>
    /// <returns>A paged list of t</returns>
    public static IPagedList<T> DataListToPagedList<T>(this JToken jToken, int pageIndex,
        int pageSize,
        bool getOnlyTotalCount = false)
    {   
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var objList = System.Text.Json.JsonSerializer.Deserialize<IList<T>>(JsonConvert.SerializeObject(jToken["data"]),options);

        var pagedList = objList.AsQueryable().ToPagedList(pageIndex, pageSize).GetAwaiter().GetResult(); //new PagedList<T>((IList<T>)objList, pageIndex, pageSize, new int?(0));
        return pagedList;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="jToken"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="searchFunc"></param>
    /// <param name="getOnlyTotalCount"></param>
    /// <returns></returns>
    public static IPagedList<T> ToPagedList<T>(this JToken jToken, int pageIndex, int pageSize, string searchFunc = null,bool getOnlyTotalCount = false)
    {
        if(jToken != null)
        {
            var objList = jToken.ToObject<IList<T>>();
            if (pageSize < 5 || pageSize > 20)
            {
                return objList.AsQueryable().ToPagedList(pageIndex, pageSize).GetAwaiter().GetResult();
            }
            else
            {
                return objList.AsQueryable().O9ToPagedList(pageIndex, pageSize).GetAwaiter().GetResult();
            }
        }
        
        return new PagedList<T>(new List<T>(), pageIndex, pageSize);
    }


    /// <summary>
    /// Returns the paged list model using the specified items
    /// </summary>
    /// <typeparam name="TEntity">The entity</typeparam>
    /// <typeparam name="T">The </typeparam>
    /// <param name="items">The items</param>
    /// <returns>A paged list model of t entity and t</returns>
    public static PagedListModel<TEntity, T> ToPagedListModel<TEntity, T>(
        this IPagedList<TEntity> items)
        where T : BaseNeptuneModel
    {
        return new PagedListModel<TEntity, T>(items);
    }

    public static PageListModel ToPageListModel(this IPagedList<JObject> items, int total)
    {
        return new PageListModel(items, total);
    }   

    /// <summary>
    /// Oes the 9 to paged list using the specified source
    /// </summary>
    /// <typeparam name="T">The </typeparam>
    /// <param name="source">The source</param>
    /// <param name="pageIndex">The page index</param>
    /// <param name="pageSize">The page size</param>
    /// <param name="getOnlyTotalCount">The get only total count</param>
    /// <returns>A task containing a paged list of t</returns>
    public static async Task<IPagedList<T>> O9ToPagedList<T>(this IQueryable<T> source, int pageIndex, int pageSize, bool getOnlyTotalCount = false)
    {
        if (source == null)
        {
            return new PagedList<T>(new List<T>(), pageIndex, pageSize);
        }

        if (pageSize == 0)
        {
            pageSize = int.MaxValue;
        }

        pageSize = Math.Max(pageSize, 1);
        List<T> data = new List<T>();
        if (!getOnlyTotalCount)
        {
            List<T> list = data;
            list.AddRange(await source.TakeSearchResult(pageIndex,pageSize));
        }

        return new PagedList<T>(data, pageIndex, pageSize, data.Count);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    public static async Task<List<T>> TakeSearchResult<T>(this IQueryable<T> source, int pageIndex, int pageSize)
    {
        pageIndex = pageIndex + 1;
        var pagingSource = (int) Math.Ceiling((double)source.Count() / pageSize);
        if(pagingSource == 0) pagingSource =1;
        var skip = pageIndex % pagingSource != 0 ? pageIndex % pagingSource - 1 : (pageIndex - 1) % pagingSource;
        var result = await source.Skip(skip*pageSize).Take(pageSize).ToListAsync();
        return result;
    }
    
    /// <summary>
    /// Returns the response model using the specified source
    /// </summary>
    /// <typeparam name="T">The </typeparam>
    /// <param name="source">The source</param>
    /// <returns>The obj list</returns>
    public static T ToResponseModel<T>(this JsonBackOffice source)
    {
        var objList =System.Text.Json.JsonSerializer.Deserialize<T>(JsonConvert.SerializeObject(source.TXBODY[0].DATA));
        return objList;
    }

    public class PageListModel : PagedModel
    {
        public int TotalCount { get; }

        public int TotalPages { get; }

        public bool HasPreviousPage { get; }

        public bool HasNextPage { get; }

        public List<JObject> Items { get; set; } = new List<JObject>();


        public PageListModel()
        {
        }

        //
        // Parameters:
        //   items:
        public PageListModel(IPagedList<JObject> items, int total)
        {
            base.PageIndex = items.PageIndex;
            base.PageSize = items.PageSize;
            TotalCount = total;
            TotalPages = items.PageSize != 0 ? (int)Math.Ceiling((double)(total / items.PageSize)) : items.TotalPages;
            HasPreviousPage = items.HasPreviousPage;
            HasNextPage = items.HasNextPage;
            Items.AddRange(items);
        }
    }
}