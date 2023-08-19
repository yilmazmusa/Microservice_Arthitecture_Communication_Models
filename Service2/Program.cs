using System.Net.Http;


HttpClient httpClient = new();

HttpResponseMessage response =  await httpClient.GetAsync("https://localhost:7067/api/Values"); // Bu adrese istek atıyoruz.

if(response.IsSuccessStatusCode)
{
    Console.WriteLine(await response.Content.ReadAsStringAsync());
} 