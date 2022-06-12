namespace SpaceNorris.API.Application.Tools;

public class StarWarsApi
{
    private readonly HttpClient _client = new ();
    private const string BaseUrl = "https://swapi.dev";
    
    public async Task<string> PeopleAsync()
    {
        var responseMessage = await _client.GetAsync($"{BaseUrl}/api/people");

        if (!responseMessage.IsSuccessStatusCode)
            throw new Exception(await responseMessage.Content.ReadAsStringAsync());

        var people = await responseMessage.Content.ReadAsStringAsync();

        return people;
    }
    
    public async Task<StarWarsPeopleDto> SearchAsync(string query)
    {
        var responseMessage = await _client.GetAsync($"{BaseUrl}/api/people?search={query}");

        if (!responseMessage.IsSuccessStatusCode)
            throw new Exception(await responseMessage.Content.ReadAsStringAsync());

        var people = await responseMessage.Content.ReadAsStringAsync();

        return new StarWarsPeopleDto
        {
            StartWarsPeople = people,
            OriginUrl = BaseUrl
        };
    }
}