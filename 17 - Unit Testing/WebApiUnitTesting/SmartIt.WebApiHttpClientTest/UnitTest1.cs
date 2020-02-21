using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SmartIt.WebApiHttpClientTest.Lib;
using Xunit;

namespace SmartIt.WebApiHttpClientTest
{
  public class ApiUnitTest1
  {
    private const string _baseUri = "http://localhost:44228/";

  [Fact]
  public async Task TestGet()
  {
    //arrange
    using (HttpClient client = new HttpClient())
    {
      client.BaseAddress = new Uri(_baseUri);
      //act
      HttpResponseMessage response = await client.GetAsync("api/Values/Get");

      var result = response.Content.ReadAsStringAsync();
      // assert
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);

      var outputModel = response.ContentAsType<List<String>>();
      Assert.Equal(expected: 2, actual: outputModel.Count);
    }
  }

  [Fact]
  public async Task TestPost()
  {
    var content = new StringContent(JsonConvert.SerializeObject("Post-Value"), Encoding.UTF8, "application/json");
    //arrange
    using (HttpClient client = new HttpClient())
    {
      client.BaseAddress = new Uri(_baseUri);
      //act
      HttpResponseMessage response = await client.PostAsync("api/values/Post", content);

      var result = response.ContentAsString();
      // assert
      Assert.Equal(expected: HttpStatusCode.Created, actual: response.StatusCode);
      Assert.Equal(expected: "Post-Value", actual: result);
    }
  }
}
}