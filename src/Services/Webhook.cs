// ASR-SAST-007: SSRF — HttpClient.GetAsync on caller-controlled URL.
public class Webhook
{
    private readonly HttpClient _http = new();
    public async Task<int> EchoAsync(string url)
    {
        var r = await _http.GetAsync(url);
        return (int)r.StatusCode;
    }
}
