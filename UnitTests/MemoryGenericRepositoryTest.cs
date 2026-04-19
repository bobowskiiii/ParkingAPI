using Domain.Common;
using Domain.Entities;
using Infrastructure.Memory;

public class MemoryGenericRepositoryTest
{
    private readonly IGenericRepositoryAsync<Vehicle> _repo = new MemoryGenericRepository<Vehicle>();

    [Fact]
    public async Task AddVehicleToRepositoryTestAsync()
    {
        var expected = new Vehicle("SJ6464F", "BMW", "Czarny");
        await _repo.AddAsync(expected);
        
        var actual = await _repo.GetByIdAsync(expected.Id);
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
        Assert.Equal(expected.Id, actual?.Id);
    }

    [Fact]
    public async Task FindAllAsync_ReturnsAllVehicles()
    {
        var v1 = new Vehicle("WE4323F", "Audi", "Biały");
        var v2 = new Vehicle("SJ7432D", "Ford", "Czarny");
        await _repo.AddAsync(v1);
        await _repo.AddAsync(v2);
        
        var result = await _repo.GetAllAsync();
        
        Assert.Contains(v1, result);
        Assert.Contains(v2, result);
    }

    [Fact]
    public async Task RemoveByIdAsync_RemovesVehicle()
    {
        var vehicle = new Vehicle("KR1234, ", "Toyota", "Czerwony");
        await _repo.AddAsync(vehicle);
        await _repo.DeleteAsync(vehicle.Id);
        
        var actual = await _repo.GetByIdAsync(vehicle.Id);
        Assert.Null(actual);
    }

    [Fact]
    public async Task UpdateAsync_UpdatesVehicle()
    {
        var vehicle = new Vehicle("GD5255C", "Volvo", "Zielony");
        await _repo.AddAsync(vehicle);

        vehicle.UpdateColor("Bursztynowy");
        await _repo.UpdateAsync(vehicle);
        
        var actual = await _repo.GetByIdAsync(vehicle.Id);
        Assert.Equal("Bursztynowy", actual?.Color);
    }

    [Fact]
    public async Task FindPagedAsync_ReturnsCorrectPage()
    {
        for (int i = 0; i < 10; i++)
        {
            await _repo.AddAsync(new Vehicle("XD1234F", "VW", "Niebieski"));
        }
        
        var result = await _repo.GetPagedAsync(page: 1, pageSize: 3);
        
        Assert.Equal(3, result.Items.Count);
        Assert.Equal(4, result.TotalPages);
        Assert.True(result.HasNext);
        Assert.False(result.HasPrevious);
    }

    [Fact]
    public async Task RemoveByIdAsync_ThrowsWhenNotFound()
    {
        await Assert.ThrowsAsync<KeyNotFoundException>(() =>
            _repo.DeleteAsync(Guid.NewGuid()));
    }   

    [Fact]
    public async Task AddAsync_ThrowsWhenDuplicateId()
    {
        var vehicle = new Vehicle ("GD5255C", "Porsche", "Cyjanowy");
        await _repo.AddAsync(vehicle);
        
        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _repo.AddAsync(vehicle));
    }
}