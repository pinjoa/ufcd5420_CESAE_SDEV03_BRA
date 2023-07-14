//
// para ver e pesquisar mais sobre este assunto:
// https://learn.microsoft.com/en-us/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client
// https://learn.microsoft.com/en-us/dotnet/fundamentals/networking/http/httpclient
// https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=net-7.0
//
using Agenda_Models2Api;
using Newtonsoft.Json;

internal class Program
{
    static readonly HttpClient client = new HttpClient();

    private static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        try
        {
            string a = "https://localhost:7273";
            string b = $"{a}/api/Agenda";
            using HttpResponseMessage response = await client.GetAsync(b);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);

            List<AgendaRegistoResponse> lista = 
                JsonConvert.DeserializeObject<List<AgendaRegistoResponse>>(responseBody);
            if (lista != null && lista.Count > 0)
            {
                foreach (var item in lista)
                {
                    Console.WriteLine($"{item.Id}\t{item.Data}\t{item.Nome}\t{item.Assunto}\t{item.Prioridade}");
                }
            } 
            else
            {
                Console.WriteLine("Lista vazia!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}