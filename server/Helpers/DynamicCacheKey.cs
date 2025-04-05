using BooksProj.Interfaces;

namespace BooksProj.Helpers;

public static class DynamicCacheKey
{
    private const string Prefix = "BookCache";
    public static string GetCacheKey(QueryObject query)
    {
        if (!string.IsNullOrEmpty(query.Title) && !string.IsNullOrEmpty(query.Author))
            return $"{Prefix}_Title_{query.Title}_Author_{query.Author}";
            
        if (!string.IsNullOrEmpty(query.Title))
            return $"{Prefix}_Title_{query.Title}";
            
        if (!string.IsNullOrEmpty(query.Author))
            return $"{Prefix}_Author_{query.Author}";
            
        return $"{Prefix}_All";
    }
    
    public static string GetRemoveAllCacheKey()
    {
        return $"{Prefix}_*";
    }
}