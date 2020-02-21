using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartIt.WebApi.Controllers;
using Xunit;

namespace SmartIt.WebApiTest
{
  public class ValuesControllerTests
  {
    [Fact]
    public async Task TestGet()
    {
      // Arrange
      var controller = new ValuesController();

      // Act
      IActionResult actionResult = await controller.Get();

      // Assert
      Assert.NotNull(actionResult);

      OkObjectResult result = actionResult as OkObjectResult;

      Assert.NotNull(result);

      List<string> messages = result.Value as List<string>;

      Assert.Equal(2, messages.Count);
      Assert.Equal("value1", messages[0]);
      Assert.Equal("value2", messages[1]);
    }


    [Fact]
    public async Task TestPost()
    {
      // Arrange
      var controller = new ValuesController();

      // Act
      IActionResult actionResult = await controller.Post("Some value");

      // Assert
      Assert.NotNull(actionResult);
      CreatedResult result = actionResult as CreatedResult;

      Assert.NotNull(result);
      Assert.Equal(201, result.StatusCode);
    }
  }
}