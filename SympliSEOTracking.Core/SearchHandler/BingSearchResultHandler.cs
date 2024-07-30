using System.Text.RegularExpressions;

namespace SympliSEOTracking.Core;

public class BingSearchResultHandler : ISearchResultHandler
{
    public async Task<List<int>> GetUrlRankAsync(string targetUrl, string rawHtml)
    {
        targetUrl = targetUrl.ToLower();

        var pattern = @"<a\s+(?:[^>]*?\s+)?href=""(https?://(?![^""]*bing)[^\s""]+)""";

        var ranks = new List<int>(); 
        var currentRank = 0;

        var regex = new Regex(pattern, RegexOptions.IgnoreCase);

        var matches = regex.Matches(rawHtml);
        foreach (Match match in matches)
        {
            var url = match.Groups[1].Value.ToLower();
            currentRank++;

            // Compare the URL with the target URL
            if (url.Contains(targetUrl))
            {
                ranks.Add(currentRank);
            }
        }

        return ranks;
    }

    public async Task<string> GetSearchResultAsync(string targetUrl, string searchTerm)
    {
        var url = $"https://www.bing.com/search?q={Uri.EscapeDataString(searchTerm)}";

        using var client = new HttpClient();
        client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");
        return await client.GetStringAsync(url);
    }
}