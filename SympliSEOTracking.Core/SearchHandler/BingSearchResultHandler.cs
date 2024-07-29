using System.Text.RegularExpressions;

namespace SympliSEOTracking.Core;

public class BingSearchResultHandler : ISearchResultHandler
{
    public async Task<List<int>> GetUrlRankAsync(string targetUrl, string rawHtml)
    {
        targetUrl = targetUrl.ToLower();

        string pattern = @"<a\s+href\s*=\s*[""'](http[s]?://[^""']+)[""'][^>]*>";

        var ranks = new List<int>(); 
        int currentRank = 0;

        var regex = new Regex(pattern, RegexOptions.IgnoreCase);

        var matches = regex.Matches(rawHtml);
        foreach (Match match in matches)
        {
            string url = match.Groups[1].Value.ToLower();
            currentRank++;

            // Compare the URL with the target URL
            if (url.Contains(targetUrl))
            {
                ranks.Add(currentRank);
            }
        }

        return ranks;
    }

    public Task<string> GetSearchResultAsync(string targetUrl, string searchTerm)
    {
        throw new NotImplementedException();
    }
}