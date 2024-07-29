using SympliSEOTracking.ApiServiceModels.SEOTracking;
namespace SympliSEOTracking.Web;

public class SEORankingClient(HttpClient httpClient)
{
    public async Task<SearchResultRankingResponse> GetRankingAsync(string searchEngine, string searchTerm, string targetUrl, CancellationToken cancellationToken = default)
    {
        SearchResultRankingResponse? result = await httpClient
                .GetFromJsonAsync<SearchResultRankingResponse>("/SEORanking", cancellationToken);

        return result;
    }
}

