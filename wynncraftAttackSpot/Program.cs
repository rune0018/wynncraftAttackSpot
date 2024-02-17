// See https://aka.ms/new-console-template for more information
using wynncraftAttackSpot;
using Newtonsoft.Json;

List<String> list = new List<String>();
HttpClient HttpClient= new();

HttpResponseMessage FirstResponse = HttpClient.GetAsync("https://api.wynncraft.com/v3/guild/list/territory").Result;
var FirstTerrRequest = JsonConvert.DeserializeObject<Dictionary<string,Territory>>(FirstResponse.Content.ReadAsStringAsync().Result);
foreach(KeyValuePair<string,Territory> kvp in FirstTerrRequest)
{
    if (kvp.Value.guild.name.Contains("Idiot")) { list.Add(kvp.Key); }
}

bool start = false;
Thread UI = new(UserInput);
UI.Start();
while (true)
{
    if (start)
    { // https://api.wynncraft.com/v3/guild/list/territory
        HttpResponseMessage httpResponse = HttpClient.GetAsync("https://api.wynncraft.com/v3/guild/list/territory").Result;
        try
        {
            httpResponse.EnsureSuccessStatusCode();
            Console.WriteLine(httpResponse.Content.ReadAsStringAsync().Result.Length);
            string result = httpResponse.Content.ReadAsStringAsync().Result;
            Dictionary<string,Territory> territoryRequest = JsonConvert.DeserializeObject<Dictionary<string,Territory>>(result) ?? new();
            foreach(string key in list)
            {
                if (!territoryRequest[key].guild.name.Contains("Idiot"))
                {
                    Console.WriteLine("Reclaim Reclaim Reclaim");
                    break;
                }
            }
        } catch (HttpRequestException)
        {
            Console.WriteLine("dead");
            break;
        }
        Thread.Sleep(30000);
    }
}
void UserInput()
{
    Console.WriteLine("Press 'a' to start");
    while (true)
    {
        switch (Console.ReadKey().Key)
        {
            case ConsoleKey.A: 
                start = true;
                Console.Clear();
                break;
            case ConsoleKey.Escape:
                Environment.Exit(0);
                break;
            case ConsoleKey.P:
                start = false;
                break;
        }
        Console.WriteLine("Press 'a' to start");
    }
}