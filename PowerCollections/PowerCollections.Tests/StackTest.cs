using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Wintellect.PowerCollections.Tests
{
    [TestClass]
    public class StackTest
    {
        [TestMethod]
        public void PushMethodCanAddValueToLastPlaceIntoStack()
        {
            Stack<int> _stack = new Stack<int>(10);

            _stack.Push(1);
            _stack.Push(2);
            _stack.Push(3);

            Assert.AreEqual(_stack.Count, 3);
        }

        [TestMethod]
        public void TopMethodReturnLastItemFromStack()
        {
            Stack<int> _stack = new Stack<int>(10);

            _stack.Push(1);
            Boolean isTopReturnLastValue = _stack.Top() == 1;

            _stack.Push(2);
            isTopReturnLastValue = (_stack.Top() == 2) && isTopReturnLastValue;

            Assert.IsTrue(isTopReturnLastValue);
        }

        [TestMethod]
        public void PopMethodReturnLastItemFromStackAndRemoveItFromStack()
        {
            Stack<int> _stack = new Stack<int>(10);

            _stack.Push(1);
            _stack.Push(2);

            int LastValue = _stack.Top();
            int PopedValue = _stack.Pop();
            Boolean Result = (_stack.Top() != LastValue) && LastValue == PopedValue;

            Assert.IsTrue(Result);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException), "Nope, my array is full")]
        public void PushMethodOutOfRangeException()
        {
            Stack<int> _stack = new Stack<int>(2);
            _stack.Push(1);
            _stack.Push(2);
            _stack.Push(3);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Nope, my array is empty")]
        public void TopMethodException()
        {
            Stack<int> _stack = new Stack<int>(10);
            int LastItem = _stack.Top();
        }

        [TestMethod]
        public void CapacityEqualsExeptingCapacityAfterCreatingStack()
        {
            int AvailableCapacity = 100;
            Stack<int> _stack = new Stack<int>(AvailableCapacity);

            Assert.AreEqual(_stack.Capacity, AvailableCapacity);
        }

        [TestMethod]
        public void CountEqualsExeptingCountAfterPushSomeItems()
        {
            int ExpectCount = 32;

            Stack<int> _stack = new Stack<int>(100);
    
            for (int i = 0; i < ExpectCount; i++)
            {
                _stack.Push(i);
            }

            Assert.AreEqual(_stack.Count, ExpectCount);
        }

        [TestMethod]
        public void PusteExistingArrayIntoStackConstructor()
        {
            int[] Result = new int[5];
            int[] ExpectingArray = new int[] { 1, 2, 3, 4, 5};
            Stack<int> _stack = new Stack<int>(ExpectingArray);

            for (int i = 4; i >= 0; i--) 
            {
                Result[i] = _stack.Pop(); 
            }

            CollectionAssert.AreEqual(Result, ExpectingArray);
        }

        [TestMethod]
        public void TestGetEnumeratorMethod()
        {
            int[] Result = new int[5];
            int[] ExpectingArray = new int[] { 1, 2, 3, 4, 5};
            Stack<int> _stack = new Stack<int>(ExpectingArray);

            int i = 0;
            var _enumerator = _stack.GetEnumerator();
            while(_enumerator.MoveNext())
            {
                Result[i++] = (int) _enumerator.Current;
            }

            CollectionAssert.AreEqual(Result, ExpectingArray);
        }
    }
}