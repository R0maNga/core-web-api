using AutoMapper;
using BLL.Models.Input.ClothesInput;
using BLL.Models.Output.CLothesOutput;
using BLL.Services.Interfaces;
using core_web_api.Controllers;
using core_web_api.Models.Request.ClothesRequest;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Tests.Controllers.ForClothesController;

[TestFixture]
public class ClothesControllerTests
{
    [SetUp]
    public void SetUp()
    {
        _loggerMock = new Mock<ILogger<ClothesController>>();
        _clothesServiceMock = new Mock<IClothesService>();
        _mapperMock = new Mock<IMapper>();
        _clothesController = new ClothesController(_clothesServiceMock.Object, _mapperMock.Object, _loggerMock.Object);
    }


    private Mock<IClothesService> _clothesServiceMock;
    private ClothesController _clothesController;
    private Mock<IMapper> _mapperMock;
    private Mock<ILogger<ClothesController>> _loggerMock;


    [Test]
    public async Task ClothesController_GetById_NotNull()
    {
        //Arrange
        var id = new Guid("843b6695-b8ed-4e3f-71cc-08daa6f924dc");
        _clothesServiceMock.Setup(t => t.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new GetCLothesOutput { Id = Guid.NewGuid(), DefaultQuantity = 100, Name = "test name" });


        //Act            
        var _clothes = await _clothesController.GetById(id, new CancellationToken());


        //Assert
        Assert.IsNotNull(_clothes);
    }

    [Test]
    public async Task ClothesController_Get_NotNull()
    {
        //Arrange
        _clothesServiceMock.Setup(t => t.GetAsync(It.IsAny<CancellationToken>()));
        //Act
        var clothes = await _clothesController.Get(new CancellationToken());
        //Assert
        Assert.IsNotNull(clothes);
    }

    [Test]
    public async Task ClothesController_Delete_EqualToStatusCode200()
    {
        //Arrange
        var inputClothes = new DeleteClothes();
        var id = inputClothes.Id = Guid.NewGuid();

        _clothesServiceMock.Setup(t => t.DeleteAsync(It.IsAny<DeleteClothes>(), It.IsAny<CancellationToken>()));
        //Act
        var clothes = await _clothesController.Delete(id, new CancellationToken());
        var expectedCode = new OkObjectResult(200);
        var clothesCode = new OkObjectResult(clothes);

        //Assert

        Assert.That(clothesCode.StatusCode, Is.EqualTo(expectedCode.StatusCode));
    }

    [Test]
    public async Task ClothesController_AddClothes_NotEqual()
    {
        //Arrange
        var clothes = new Clothes();
        var id = clothes.Id = Guid.NewGuid();
        var quantity = clothes.DefaultQuantity = 12;

        var inputClothes = new ClotheseUpdateRequest();
        inputClothes.Id = id;
        inputClothes.Name = "differentName";
        inputClothes.DefaultQuantity = quantity;


        _clothesServiceMock.Setup(t => t.UpdateAsync(It.IsAny<UpdateClothes>(), It.IsAny<CancellationToken>()));
        //Act
        var _clothes = await _clothesController.Update(inputClothes, new CancellationToken());


        //Assert
        Assert.AreNotEqual(clothes, _clothes);
    }

    [Test]
    public async Task ClothesController_Create_NotNull()
    {
        //Arrange
        var clothes = new ClothesCreateRequest();
        var quantity = clothes.DefaultQuantity = 12;
        var name = clothes.Name = "name";


        _clothesServiceMock.Setup(t => t.CreateAsync(It.IsAny<CreateClothes>(), It.IsAny<CancellationToken>()));
        //Act
        var _clothes = await _clothesController.Create(clothes, new CancellationToken());


        //Assert
        Assert.NotNull(_clothes);
    }
}