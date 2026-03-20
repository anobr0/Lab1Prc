using Xunit;
using FluentAssertions;
using Geometry;

namespace Geometry.Tests;

public class SegmentTests
{
    [Fact]
    public void Length_ShouldCalculateDistanceBetweenTwoPoints()
    {
        // Проверяем расчет длины отрезка между двумя точками
        var p1 = new Point(0, 0);
        var p2 = new Point(0, 10);
        var segment = new Segment(p1, p2);

        segment.Length.Should().Be(10);
    }
}