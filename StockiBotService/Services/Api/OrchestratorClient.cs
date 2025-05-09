namespace StockiBotService.Services.Api;

public class OrchestratorClient
{
    private readonly IHttpClientFactory _httpClientFactory;

    public OrchestratorClient(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<string> GetStockPriceData(string ticker)
    {
        var httpClient = _httpClientFactory.CreateClient("OrchestratorClient");
        var res = await httpClient.GetAsync($"/stock-price-data-command/{ticker}");
        res.EnsureSuccessStatusCode();
        var resString = await res.Content.ReadAsStringAsync();
        return resString;
    }
}
