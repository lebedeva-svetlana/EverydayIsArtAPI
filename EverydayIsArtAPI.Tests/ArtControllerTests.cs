using EverydayIsArtAPI.Controllers;
using EverydayIsArtAPI.Models;
using EverydayIsArtAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EverydayIsArtAPI.Tests;

public class ArtControllerTests
{
    [Fact]
    public async Task GetArt_ReturnsArt_WhenArtIsNotNull()
    {
        Art art = new() { Date = "2000", Title = "TestTitle" };
        Mock<IArtService> mock = new();
        mock.Setup(m => m.GetArt())
            .ReturnsAsync(art);
        ArtController controller = new(mock.Object);

        var result = await controller.GetArt();

        var actionResult = Assert.IsType<ActionResult<Art>>(result);
        var returnJson = Assert.IsType<JsonResult>(actionResult.Result);
        var jsonValue = (Art)returnJson.Value;
        Assert.Equal("2000", jsonValue.Date);
        Assert.Equal("TestTitle", jsonValue.Title);
    }

    [Fact]
    public async Task GetArt_ReturnsInternalServerError_WhenArtIsNull()
    {
        Mock<IArtService> mock = new();
        mock.Setup(m => m.GetArt())
            .ReturnsAsync((Art?)null);
        ArtController controller = new(mock.Object);

        var result = await controller.GetArt();

        var actionResult = Assert.IsType<ActionResult<Art>>(result);
        var returnValue = Assert.IsType<ObjectResult>(result.Result);
        Assert.Equal(500, returnValue.StatusCode);
    }
}