using Microsoft.AspNetCore.Mvc;
using SympliSEOTracking.ApiServiceModels.SEOTracking;
using SympliSEOTracking.Core;

namespace SympliSEOTracking.ApiService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SEORankingController : Controller
{
    private readonly Func<string, ISearchResultHandler?> _searchResultHandlerFactory;
    public SEORankingController(Func<string, ISearchResultHandler?> searchResultHandlerFactory)
    {
        _searchResultHandlerFactory = searchResultHandlerFactory;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetRank(string searchEngine, string searchTerm, string targetUrl)
    {
        var handler = _searchResultHandlerFactory(searchEngine);
        if (handler == null)
        {
            return BadRequest($"Sorry, {searchEngine} search engine is not supported yet =((.");
        }

        var searchResultHtml = await handler.GetSearchResultAsync(targetUrl, searchTerm);
        return Ok(new SearchResultRankingResponse(await handler.GetUrlRankAsync(targetUrl, searchResultHtml)));
    }
}