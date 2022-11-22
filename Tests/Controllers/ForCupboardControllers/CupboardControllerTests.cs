using AutoMapper;
using BLL.Models.Input.CupboardInput;
using BLL.Models.Output.CupboardOutput;
using BLL.Services.Interfaces;
using core_web_api.Controllers;
using core_web_api.Models.Request.CupboardRequest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Tests.Controllers.ForCupboardControllers;

[TestFixture]
public class CupboardControllerTests
{
    [SetUp]
    public void SetUp()
    {
        _loggerMock = new Mock<ILogger<CupboardController>>();
        _cupboardServiceMock = new Mock<ICupboardService>();
        _mapperMock = new Mock<IMapper>();
        _cupboardController =
            new CupboardController(_loggerMock.Object, _cupboardServiceMock.Object, _mapperMock.Object);
    }


    private Mock<ICupboardService> _cupboardServiceMock;
    private CupboardController _cupboardController;
    private Mock<IMapper> _mapperMock;
    private Mock<ILogger<CupboardController>> _loggerMock;


    [Test]
    public async Task GetById_NotNull_True()
    {
        //Arrange
        var id = new Guid("843b6695-b8ed-4e3f-71cc-08daa6f924dc");
        _cupboardServiceMock.Setup(t =>
            t.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>(), It.IsAny<bool>())).ReturnsAsync(
            new GetCupboardOutput
                { Id = Guid.NewGuid(), ModelId = Guid.NewGuid(), OwnerName = "testName", Name = "test name" });


        //Act            
        var cupboard = await _cupboardController.GetById(id, new CancellationToken());


        //Assert
        Assert.IsNotNull(cupboard);
    }

    [Test]
    public async Task Get_NotNull_True()
    {
        //Arrange
        _cupboardServiceMock.Setup(t => t.GetAsync(It.IsAny<CancellationToken>(), It.IsAny<bool>()));
        //Act
        var cupboard = await _cupboardController.Get(new CancellationToken());
        //Assert
        Assert.IsNotNull(cupboard);
    }

    [Test]
    public async Task Delete_EqualToStatusCode200_True()
    {
        //Arrange
        var inputCupboard = new DeleteCupboard();
        var id = inputCupboard.Id = Guid.NewGuid();
        var expectedCode = new OkObjectResult(200);
        _cupboardServiceMock.Setup(t => t.DeleteAsync(It.IsAny<DeleteCupboard>(), It.IsAny<CancellationToken>()));
        //Act
        var cupboard = await _cupboardController.Delete(id, new CancellationToken());
        var cupboardCode = new OkObjectResult(cupboard);

        //Assert
        Assert.That(cupboardCode.StatusCode, Is.EqualTo(expectedCode.StatusCode));
    }

    [Test]
    public async Task Update_NotEqual_True()
    {
        //Arrange
        var cupboard = new UpdateCupboard();
        var id = cupboard.Id = Guid.NewGuid();
        var inputCupboard = new UpdateCupboardRequest();
        inputCupboard.Id = id;
        inputCupboard.Name = "differentName";
        _cupboardServiceMock.Setup(t => t.UpdateAsync(It.IsAny<UpdateCupboard>(), It.IsAny<CancellationToken>()));

        //Act
        var cupboardData = await _cupboardController.Update(inputCupboard, new CancellationToken());

        //Assert
        Assert.AreNotEqual(cupboard, cupboardData);
    }

    [Test]
    public async Task Create_NotNull_True()
    {
        //Arrange
        var cupboard = new CreateCupboardRequest();
        _cupboardServiceMock.Setup(t => t.CreateAsync(It.IsAny<CreateCupboard>(), It.IsAny<CancellationToken>()));

        //Act
        var cupboardData = await _cupboardController.Create(cupboard, new CancellationToken());

        //Assert
        Assert.NotNull(cupboardData);
    }
}