using Xunit;
using FluentAssertions;
using Geometry;

namespace Geometry.Tests;

public class PolygonalChainTests
{
    [Fact]
    public void Length_WithMidpoints_ShouldCalculateTotalPath()
    {
        // Проверяем длину ломаной: (0,0) -> (0,5) -> (5,5) = 10
        var chain = new PolygonalChain(new Point(0, 0), new Point(5, 5));
        chain.AddMidpoint(new Point(0, 5));

        chain.Length.Should().Be(10);
    }

    [Fact]
    public void ToString_ShouldReturnCorrectFormat()
    {
        // Проверяем текстовый формат вывода всех точек
        var chain = new PolygonalChain(new Point(0, 0), new Point(2, 2));
        chain.AddMidpoint(new Point(1, 1));

        chain.ToString().Should().Be("(0,0),(1,1),(2,2)");
    }
}
