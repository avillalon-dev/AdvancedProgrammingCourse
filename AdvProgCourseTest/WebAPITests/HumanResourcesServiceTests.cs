using Model;
using System.IO;
using System.Net.Http.Headers;

namespace WebAPITests
{
    [TestClass]
    public class HumanResourcesServiceTests
    {
        [TestMethod]
        public async Task Can_GetWorker_Test()
        {
            // arrange
            HttpClient client = new HttpClient();
            // Update port # in the following line.
            client.BaseAddress = new Uri("https://localhost:7224/");
            // Sets the Accept header to "application/json".Setting this header tells the server to send data in JSON format.
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            // act
            Worker worker = null;
            HttpResponseMessage response = await client.GetAsync(@"HumanResources\GetWorkers");
            if (response.IsSuccessStatusCode)
            {
                worker = await response.Content.ReadAsAsync<Worker>();
            }

            // assert
            Assert.IsNotNull(worker);
        }
    }
}