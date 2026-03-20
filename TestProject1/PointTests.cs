using Xunit;
using FluentAssertions;
using Geometry;

namespace Geometry.Tests;

public class PointTests
{
    [Fact]
    public void Constructor_Default_ShouldSetCoordinatesToZero()
    {
        // Проверяем, что конструктор без параметров создает точку (0,0)
        var point = new Point();
        point.X.Should().Be(0);
        point.Y.Should().Be(0);
    }

    [Fact]
    public void Move_ShouldIncreaseCoordinatesCorrectly()
    {
        // Проверяем метод смещения точки
        var point = new Point(10, 10);
        point.Move(5, -2);

        point.X.Should().Be(15);
        point.Y.Should().Be(8);
    }

    [Fact]
    public void Distance_ShouldReturnCorrectLengthFromOrigin()
    {
        // Проверяем расчет расстояния до центра (3,4,5 - египетский треугольник)
        var point = new Point(3, 4);
        point.Distance().Should().Be(5);
    }
}
