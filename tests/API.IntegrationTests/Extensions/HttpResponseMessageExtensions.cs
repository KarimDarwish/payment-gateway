using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace API.IntegrationTests.Extensions;

public static class HttpResponseMessageExtensions
{
    public static async Task<T> Deserialize<T>(this HttpResponseMessage message)
    {
        return JsonConvert.DeserializeObject<T>(await message.Content.ReadAsStringAsync());
    }
}