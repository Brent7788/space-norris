namespace SpaceNorris.API.Application.Tools;

public class ChuckNorrisApi
{
    private readonly HttpClient _client = new ();
    private const string BaseUrl = "https://api.chucknorris.io";
    private static readonly string[] ChuckNorrisCategories = {"animal", "career", "celebrity", "dev", "explicit", "fashion", "food", 
        "history", "money", "movie", "music", "political", "religion", "science", "sport", "travel"};

    public async Task<string> SearchAsync(string query)
    {
        var responseMessage = await _client.GetAsync($"{BaseUrl}/jokes/search?query={query}");

        if (!responseMessage.IsSuccessStatusCode)
            throw new Exception(); //TODO Need get the message from the response

        var jokes = await responseMessage.Content.ReadAsStringAsync();

        return jokes;
    }

    public string[] Categories => ChuckNorrisCategories;
}