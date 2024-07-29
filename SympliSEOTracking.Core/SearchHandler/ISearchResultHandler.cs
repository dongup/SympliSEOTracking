namespace SympliSEOTracking.Core;

public interface ISearchResultHandler
{
     Task<List<int>> GetUrlRankAsync(string targetUrl, string searchResultHtml);
     Task<string> GetSearchResultAsync(string targetUrl, string searchTerm);
}