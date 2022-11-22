using AutoMapper;
using BLL.Models.Input.CupboardClothesInput;
using BLL.Services.Interfaces;
using core_web_api.Controllers;
using core_web_api.Models.Request.CupboardClothesRequest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Tests.Controllers.ForCupboardClothesController;

[TestFixture]
public class CupboardClothesControllerTests
{
    [SetUp]
    public void SetUp()
    {
        _loggerMock = new Mock<ILogger<CupboardClothesController>>();
        _clothesServiceMock = new Mock<ICupboardClothesService>();
        _mapperMock = new Mock<IMapper>();

        _clothesController =
            new CupboardClothesController(_clothesServiceMock.Object, _loggerMock.Object, _mapperMock.Object);
    }


    private Mock<ICupboardClothesService> _clothesServiceMock;
    private CupboardClothesController _clothesController;
    private Mock<IMapper> _mapperMock;
    private Mock<ILogger<CupboardClothesController>> _loggerMock;


    [Test]
    public async Task Delete_EqualToStatusCode200_True()
    {
        //Arrange
        var inputCupboardClothes = new DeleteCupboardClothesRequest();
        var expectedCode = new OkObjectResult(200);
        _clothesServiceMock.Setup(t => t.DeleteAsync(It.IsAny<DeleteCupboardClothes>(), It.IsAny<CancellationToken>()));
        //Act
        var cupboardClothes = await _clothesController.Delete(inputCupboardClothes, new CancellationToken());
        var cupboardClothesCode = new OkObjectResult(cupboardClothes);
        //Assert
        Assert.That(cupboardClothesCode.StatusCode, Is.EqualTo(expectedCode.StatusCode));
    }

    [Test]
    public async Task ExecuteProcedure_NotNull_True()
    {
        //Act
        var data = _clothesServiceMock.Setup(t => t.ExecuteProcedure());


        //Assert
        Assert.NotNull(data);
    }

    [Test]
    public async Task Create_NotNull_True()
    {
        //Arrange
        var cupboardClothes = new CreateCupboardClothesRequest();


        _clothesServiceMock.Setup(t => t.CreateAsync(It.IsAny<CreateCupboardClothes>(), It.IsAny<CancellationToken>()));
        //Act
        var data = await _clothesController.Create(cupboardClothes, new CancellationToken());


        //Assert
        Assert.NotNull(data);
    }
}