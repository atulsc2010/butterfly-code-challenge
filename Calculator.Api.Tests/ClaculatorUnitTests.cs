using Xunit;
using Calculator.Api.Domain;
using FluentAssertions;

namespace Calculator.Api.Tests
{
    public class ClaculatorUnitTests
    {
        [Fact]
        public void Add_should_return_sum_when_input_is_valid()
        {
            // Arrange
            var calc = new CalculatorCore();

            // Act 
            var result = calc.Add(1, 2);
            var result2 = calc.Add(-1, -2);
            var result3 = calc.Add(-1.5, -2.8);

            // Assert
            //Assert.Equal(3 , result);
            result.Should().Be(3);
            result2.Should().Be(-3);
            result3.Should().Be(-4.3);
        }

        [Fact]
        public void Add_should_return_NaN_when_overflow_occurs()
        {
            // Arrange
            var calc = new CalculatorCore();

            // Act 
            var result = calc.Add(double.MaxValue, 1);

            // Assert
            result.Should().Be(double.NaN);

            // Sum exceeding Max/Min value
            var result2 = calc.Add(double.MaxValue * 0.5 , double.MaxValue * 0.5);
            var result3 = calc.Add(double.MinValue * 0.5 , double.MinValue * 0.5);
            
            // Assert
            result2.Should().Be(double.NaN);
            result3.Should().Be(double.NaN);
        }

        [Fact]
        public void Subtract_should_return_difference()
        {
            // Arrange
            var calc = new CalculatorCore();

            // Act 
            var result = calc.Subtract(2, 1);
            var result2 = calc.Subtract(-2, -1);

            // Assert
            result.Should().Be(1);
            result2.Should().Be(-1);

        }

        [Fact]
        public void Subtract_should_return_NaN_when_overflow_occurs()
        {
            // Arrange
            var calc = new CalculatorCore();

            // Act 
            var result = calc.Subtract(double.MinValue, -1);

            // Assert
            result.Should().Be(double.NaN);
        }

        [Fact]
        public void Multiply_should_return_product()
        {
            // Arrange
            var calc = new CalculatorCore();

            // Act 
            var result = calc.Multiply(2, 2);
            var result2 = calc.Multiply(-2, -2);
            var result3 = calc.Multiply(-2.5, 2);

            // Assert
            result.Should().Be(4);
            result2.Should().Be(4);
            result3.Should().Be(-5);
        }

        [Fact]
        public void Multiply_should_return_NaN_when_overflow_occurs()
        {
            // Arrange
            var calc = new CalculatorCore();

            // Act 
            var result = calc.Multiply(double.MaxValue, 2);
            var result2 = calc.Multiply(double.MinValue, 2);

            // Assert
            result.Should().Be(double.NaN);
            result2.Should().Be(double.NaN);
        }

        [Fact]
        public void Divide_should_return_fraction()
        {
            // Arrange
            var calc = new CalculatorCore();

            // Act 
            var result = calc.Divide(4, 2);
            var result2 = calc.Divide(-4, -2);

            // Assert
            result.Should().Be(2);
            result2.Should().Be(2);
        }

        [Fact]
        public void Divide_should_return_NaN_when_devided_by_zero()
        {
            // Arrange
            var calc = new CalculatorCore();

            // Act 
            var result = calc.Divide(4, 0);
            var result2 = calc.Divide(double.MaxValue, 1);

            // Assert
            result.Should().Be(double.NaN);
            result2.Should().Be(double.NaN);
        }
    }
}
