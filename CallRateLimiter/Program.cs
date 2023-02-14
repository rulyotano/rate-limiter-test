// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var httpClient = new HttpClient();
httpClient.BaseAddress = new Uri("http://localhost:5086");

var allTasks = new List<Task>();
foreach (var _ in Enumerable.Range(1, 100))
{
    allTasks.Add(CallRateLimiter());
}

await Task.WhenAll(allTasks);

Console.WriteLine("All request completed");

async Task CallRateLimiter()
{
    var response = await httpClient.GetAsync("/weatherforecast");
    Console.WriteLine("Response status: {0}", response.StatusCode);
}
