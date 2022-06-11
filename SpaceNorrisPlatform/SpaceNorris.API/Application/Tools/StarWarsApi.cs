namespace SpaceNorris.API.Application.Tools;

public class StarWarsApi
{
    private readonly HttpClient _client = new ();
    private const string BaseUrl = "https://swapi.dev";
    
    public async Task<string> PeopleAsync()
    {
        var responseMessage = await _client.GetAsync($"{BaseUrl}/api/people");

        if (!responseMessage.IsSuccessStatusCode)
            throw new Exception(); //TODO Need get the message from the response

        var people = await responseMessage.Content.ReadAsStringAsync();

        return people;
    }
    
    public async Task<string> SearchAsync(string query)
    {
        var responseMessage = await _client.GetAsync($"{BaseUrl}/api/people?search={query}");

        if (!responseMessage.IsSuccessStatusCode)
            throw new Exception(); //TODO Need get the message from the response

        var people = await responseMessage.Content.ReadAsStringAsync();

        return people;
    }
}