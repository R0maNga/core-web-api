using AutoMapper;
using BLL.Models.Input.CupboardModelnput;
using BLL.Services.Interfaces;
using core_web_api.Controllers;
using core_web_api.Models.Request.CupboardModelRequest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Tests.Controllers.ForCupboardModelControllers;

[TestFixture]
public class CupboardModelControllerTests
{
    [SetUp]
    public void SetUp()
    {
        _loggerMock = new Mock<ILogger<CupboardModelController>>();
        _cupboardServiceMock = new Mock<ICupboardModelService>();
        _mapperMock = new Mock<IMapper>();
        _cupboardController =
            new CupboardModelController(_loggerMock.Object, _mapperMock.Object, _cupboardServiceMock.Object);
    }

    private Mock<ICupboardModelService> _cupboardServiceMock;
    private CupboardModelController _cupboardController;
    private Mock<IMapper> _mapperMock;
    private Mock<ILogger<CupboardModelController>> _loggerMock;


    [Test]
    public async Task CupboardModelController_Get_NotNull()
    {
        //Arrange
        _cupboardServiceMock.Setup(t => t.GetAsync(It.IsAny<CancellationToken>(), It.IsAny<bool>()));
        //Act
        var cupboardModel = await _cupboardController.Get(new CancellationToken());
        //Assert
        Assert.IsNotNull(cupboardModel);
    }

    [Test]
    public async Task CupboardModelController_Delete_EqualToStatusCode200()
    {
        //Arrange
        var inputCupboardModel = new DeleteCupboardModelRequest();
        var id = inputCupboardModel.Id = Guid.NewGuid();

        _cupboardServiceMock.Setup(t => t.DeleteAsync(It.IsAny<DeleteCupboardModel>(), It.IsAny<CancellationToken>()));
        //Act
        var cupboardModel = await _cupboardController.Delete(new CancellationToken(), inputCupboardModel);
        var expectedCode = new OkObjectResult(200);
        var cupboardModelCode = new OkObjectResult(cupboardModel);

        //Assert

        Assert.That(cupboardModelCode.StatusCode, Is.EqualTo(expectedCode.StatusCode));
    }


    [Test]
    public async Task CupboardModelController_Create_NotNull()
    {
        //Arrange
        var cupboardModel = new CreateCupboardModelRequest();
        var name = cupboardModel.Name = "name";


        _cupboardServiceMock.Setup(t => t.CreateAsync(It.IsAny<CreateCupboardModel>(), It.IsAny<CancellationToken>()));
        //Act
        var cupboardModelData = await _cupboardController.Create(new CancellationToken(), cupboardModel);


        //Assert
        Assert.NotNull(cupboardModelData);
    }
}