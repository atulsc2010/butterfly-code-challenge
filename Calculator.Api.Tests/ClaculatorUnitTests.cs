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

            // Assert
            //Assert.Equal(3 , result);
            result.Should().Be(3);
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
        }

        [Fact]
        public void Subtract_should_return_difference()
        {
            // Arrange
            var calc = new CalculatorCore();

            // Act 
            var result = calc.Subtract(2, 1);

            // Assert
            result.Should().Be(1);

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

            // Assert
            result.Should().Be(4);
        }

        [Fact]
        public void Multiply_should_return_NaN_when_overflow_occurs()
        {
            // Arrange
            var calc = new CalculatorCore();

            // Act 
            var result = calc.Multiply(double.MaxValue, 2);

            // Assert
            result.Should().Be(double.NaN);
        }

        [Fact]
        public void Divide_should_return_fraction()
        {
            // Arrange
            var calc = new CalculatorCore();

            // Act 
            var result = calc.Divide(4, 2);

            // Assert
            result.Should().Be(2);
        }

        [Fact]
        public void Divide_should_return_NaN_when_devided_by_zero()
        {
            // Arrange
            var calc = new CalculatorCore();

            // Act 
            var result = calc.Divide(4, 0);

            // Assert
            result.Should().Be(double.NaN);
        }
    }
}
