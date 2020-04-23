using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestNinja.UnitTests
{
    public class StackTests
    {
        [Fact]
        public void Push_WhenCalled_AddsItemToStackAndIncrementsCount()
        {
            // Arrange
            var stack = new Fundamentals.Stack<int>();

            // Act
            stack.Push(1);

            // Assert
            Assert.Equal(1, stack.Count);
            Assert.Equal(1, stack.Peek());
        }

        [Fact]
        public void Push_WhenNullAdded_ThrowsArgumentNullException()
        {
            // Arrange
            var stack = new Fundamentals.Stack<int?>();

            // Act & Arrange
            Assert.Throws<ArgumentNullException>(() => stack.Push(null));
        }

        [Fact]
        public void Pop_WhenCalledOnNonEmptyStack_ReturnsTopStackItemAndDecrementsCount()
        {
            // Arrange
            var stack = new Fundamentals.Stack<int?>();

            // Act
            stack.Push(1);
            stack.Push(2);
            var result = stack.Pop();

            // Assert
            Assert.Equal(2, result);
            Assert.Equal(1, stack.Count);
        }

        [Fact]
        public void Pop_WhenCalledOnEmptyStack_ThrowsInvalidOperationException()
        {
            // Arrange
            var stack = new Fundamentals.Stack<int?>();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Fact]
        public void Peek_WhenCalledOnNonEmptyStack_ReturnsTopStackItem()
        {
            // Arrange
            var stack = new Fundamentals.Stack<int?>();

            // Act
            stack.Push(1);
            stack.Push(2);
            var result = stack.Peek();

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void Peek_WhenCalledOnEmptyStack_ThrowsInvalidOperationException()
        {
            // Arrange
            var stack = new Fundamentals.Stack<int?>();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }
    }
}