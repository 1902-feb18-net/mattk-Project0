﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Project0.Test
{
    public class OrderTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(500)]
        [InlineData(499)]
        [InlineData(250)]
        public void TestCheckCupcakeQuantityTrue(int qnty)
        {
            // Act and Assert
            Assert.True(Library.Order.CheckCupcakeQuantity(qnty));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(501)]
        [InlineData(1000)]
        [InlineData(-500)]
        public void TestCheckCupcakeQuantityFalse(int qnty)
        {
            // Act and Assert
            Assert.False(Library.Order.CheckCupcakeQuantity(qnty));
        }
    }
}
