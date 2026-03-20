using Xunit;
using FluentAssertions;
using Automotive;

namespace Automotive.Tests;

public class CarTests
{
    [Fact]
    public void Constructor_ValidData_ShouldCreateCar()
    {
        // Проверяем успешное создание объекта
        var car = new Car("Toyota", 50, 8);
        car.Brand.Should().Be("Toyota");
        car.TankCapacity.Should().Be(50);
    }

    [Fact]
    public void Constructor_EmptyBrand_ShouldThrowException()
    {
        // Проверка защиты от пустых строк в названии бренда
        Action act = () => new Car("", 50, 8);
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Refuel_ShouldNotExceedTankCapacity()
    {
        // Проверка, что нельзя заправить больше, чем влезет в бак
        var car = new Car("BMW", 40, 10);
        car.Refuel(100);

        car.CurrentFuelLevel.Should().Be(40);
    }

    [Fact]
    public void Drive_ShouldReduceFuelAndIncreaseOdometer()
    {
        // Проверка расхода топлива и пробега
        var car = new Car("Audi", 60, 10); // 10л на 100км
        car.Refuel(20);
        car.Drive(100);

        car.CurrentFuelLevel.Should().Be(10); // Осталось 10 (было 20 - потрачено 10)
        car.Odometer.Should().Be(100);
    }

    [Fact]
    public void Drive_WhenOutOffFuel_ShouldStopCar()
    {
        // Проверка: машина проедет только столько, на сколько хватит бензина
        var car = new Car("Fiat", 50, 10);
        car.Refuel(5); // Хватит на 50 км
        car.Drive(200);

        car.Odometer.Should().Be(50);
        car.CurrentFuelLevel.Should().Be(0);
    }

    [Fact]
    public void ResetTripOdometer_ShouldSetOnlyTripToZero()
    {
        // Проверка сброса суточного пробега
        var car = new Car("Ford", 50, 10);
        car.Refuel(10);
        car.Drive(50);

        car.ResetTripOdometer();

        car.TripOdometer.Should().Be(0);
        car.Odometer.Should().Be(50); // Основной пробег не меняется
    }
}