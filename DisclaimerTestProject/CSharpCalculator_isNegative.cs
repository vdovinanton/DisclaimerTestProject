﻿using System;
using System.Collections.Generic;
using System.Linq;
using CSharpCalculator;
using NUnit.Framework;

namespace DisclaimerTestProject
{
    [TestFixture]
    public class CSharpCalculator_isNegative
    {
        [TearDown]
        public void Cleanup()
        {
            _resultCollection = new List<bool>();
        }

        private Calculator _calc;
        private IList<bool> _resultCollection;
        private IEnumerable<double> _positiveNumbers;
        private IEnumerable<double> _negativeNumbers;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _calc = new Calculator();

            _positiveNumbers = new List<double>
            {
                41.1,
                13.4,
                7
            };

            _negativeNumbers = new List<double>
            {
                -20.1,
                -19,
                -5
            };

            _resultCollection = new List<bool>();
        }

        [Test]
        public void Exception()
        {
            var value = new { };

            Assert.That(() => _calc.isNegative(value), Throws.TypeOf<NotFiniteNumberException>());
        }

        [Test]
        public void Negative()
        {
            foreach (var value in _negativeNumbers)
                _resultCollection.Add(_calc.isNegative(value));


            Assert.AreEqual(true, _resultCollection.All(_ => _.Equals(true)),
                "All elements in collection should be true");
            Assert.AreNotEqual(false, _resultCollection.All(_ => _.Equals(true)),
                "All elements in collection should be true");
        }

        [Test]
        public void Positive()
        {
            foreach (var value in _positiveNumbers)
                _resultCollection.Add(_calc.isNegative(value));


            Assert.AreEqual(false, _resultCollection.All(_ => _.Equals(true)),
                "All elements in collection should be true");
            Assert.AreNotEqual(true, _resultCollection.All(_ => _.Equals(true)),
                "All elements in collection should be true");
        }
    }
}