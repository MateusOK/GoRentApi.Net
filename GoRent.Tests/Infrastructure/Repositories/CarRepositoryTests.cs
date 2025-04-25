using GoRent.Domain.Entities;
using GoRent.Infrastructure.Repositories;
using MongoDB.Driver;
using Moq;
using Xunit;

namespace GoRent.Tests.Infrastructure.Repositories;

public class CarRepositoryTests
{
    private readonly Mock<IMongoCollection<Car>> _mockCollection;
    private readonly CarRepository _repository;

    public CarRepositoryTests()
    {
        _mockCollection = new Mock<IMongoCollection<Car>>();
        var mockDatabase = new Mock<IMongoDatabase>();

        mockDatabase
            .Setup(db => db.GetCollection<Car>("cars", null))
            .Returns(_mockCollection.Object);
        
        _repository = new CarRepository(mockDatabase.Object);
    }

    [Fact]
    public async Task AddSync_Should_Call_InsertOneAsync()
    {
        //Arrange
        var car = new Car {Id = Guid.NewGuid(), Model = "Fusca", Year = 2020};
        
        //Act
        await _repository.AddAsync(car);
        
        //Assert
        _mockCollection.Verify(
            x=> x.InsertOneAsync(car, null, default),
            Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_Should_Call_ReplaceOneAsync()
    {
        //Arrange
        var car = new Car {Id = Guid.NewGuid(), Model = "Civic", Year = 2020};
        
        //Act
        await _repository.UpdateAsync(car);
        
        //Assert
        _mockCollection.Verify(
            x=> x.ReplaceOneAsync(
                It.IsAny<FilterDefinition<Car>>(),
                car,
                It.IsAny<ReplaceOptions>(),
                default),
            Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_Should_Call_DeleteOneAsync()
    {
        //Arrange
        var car = new Car {Id = Guid.NewGuid()};
        
        //Act
        await _repository.DeleteAsync(car);
        
        //Assert
        _mockCollection.Verify(
            x=> x.DeleteOneAsync(
                It.IsAny<FilterDefinition<Car>>(),
                default),
            Times.Once);
    }
    
}