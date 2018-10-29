using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CSharpCalculator;
using NUnit.Framework;

namespace DisclaimerTestProject
{
    [TestFixture]
    public class CSharpCalculator_abs
    {
        private IList<bool> _resultCollection;
        private IEnumerable<short> _numberShort;
        private IEnumerable<int> _numberInt;
        private IEnumerable<decimal> _numberDecimal;
        private IEnumerable<double> _numberDouble;
        private IEnumerable<string> _numberString;
        private Calculator _calc;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _calc = new Calculator();

            _numberShort = new List<short>
            {
                short.MaxValue,
                50,
                0,
                -50,
                short.MinValue
            };

            _numberInt = new List<int>
            {
                int.MaxValue,
                50,
                0,
                -50,
                int.MinValue //-804128
            };
            _numberDecimal = new List<decimal>
            {
                50,
                0,
                -50
            };
            _numberDouble = new List<double>
            {
                double.MaxValue,
                50,
                0,
                -50,
                double.MinValue
            };
            _numberString = new List<string>
            {
                double.MaxValue.ToString(CultureInfo.InvariantCulture), //1.79769313486232E+308
                "50",
                "0",
                "-50",
                double.MinValue.ToString(CultureInfo.InvariantCulture), //1.79769313486232E+308
            };

            _resultCollection = new List<bool>();
        }

        [TearDown]
        public void Cleanup()
        {
            _resultCollection = new List<bool>();
        }

        [Test]
        public void Short()
        {
            var expected = new List<double>
            {
                short.MaxValue,
                50,
                0,
                50,
                32768
            };

            foreach (var number in _numberShort)
            {
                var result = false;
                try
                {
                    result = expected.Any(_ => _.Equals(_calc.Abs(number)));
                }
                catch
                {
                    // ignored
                }

                _resultCollection.Add(result);
            }

            Assert.AreEqual(true, _resultCollection.All(_ => _.Equals(true)),
                "All elements in collection should be equal");
            Assert.AreNotEqual(false, _resultCollection.All(_ => _.Equals(true)),
                "All elements in collection shouldn't be equal");
        }

        [Test]
        public void Decimal()
        {
            var expected = new List<double>
            {
                50,
                0,
                50
            };

            foreach (var number in _numberDecimal)
            {
                var result = false;
                try
                {
                    result = expected.Any(_ => _.Equals(_calc.Abs(number)));
                }
                catch
                {
                    // ignored
                }

                _resultCollection.Add(result);
            }

            Assert.AreEqual(true, _resultCollection.All(_ => _.Equals(true)),
                "All elements in collection should be equal");
            Assert.AreNotEqual(false, _resultCollection.All(_ => _.Equals(true)),
                "All elements in collection shouldn't be equal");
        }

        [Test]
        public void Double()
        {
            var expected = new List<double>
            {
                2147483647,
                50,
                0,
                50,
                804128
            };

            foreach (var number in _numberDouble)
            {
                var result = false;
                try
                {
                    result = expected.Any(_ => _.Equals(_calc.Abs(number)));
                }
                catch
                {
                    // ignored
                }

                _resultCollection.Add(result);
            }

            Assert.AreEqual(true, _resultCollection.All(_ => _.Equals(true)),
                "All elements in collection should be equal");
            Assert.AreNotEqual(false, _resultCollection.All(_ => _.Equals(true)),
                "All elements in collection shouldn't be equal");
        }

        [Test]
        public void Int()
        {
            var expected = new List<double>
            {
                double.MaxValue,
                50,
                0,
                50,
                double.MaxValue
            };

            foreach (var number in _numberInt)
            {
                var result = false;
                try
                {
                    result = expected.Any(_ => _.Equals(_calc.Abs(number)));
                }
                catch
                {
                    // ignored
                }

                _resultCollection.Add(result);
            }

            Assert.AreEqual(true, _resultCollection.All(_ => _.Equals(true)),
                "All elements in collection should be equal");
            Assert.AreNotEqual(false, _resultCollection.All(_ => _.Equals(true)),
                "All elements in collection shouldn't be equal");
        }

        [Test]
        public void String()
        {
            var expected = new List<double>
            {
                double.MaxValue,
                50,
                0,
                50,
                double.MaxValue
            };

            foreach (var number in _numberString)
            {
                var result = false;
                try
                {
                    var res = _calc.Abs(number);
                    result = expected.Any(_ => _.Equals(res));
                }
                catch
                {
                    // ignored
                }

                _resultCollection.Add(result);
            }

            Assert.AreEqual(true, _resultCollection.All(_ => _.Equals(true)),
                "All elements in collection should be equal");
            Assert.AreNotEqual(false, _resultCollection.All(_ => _.Equals(true)),
                "All elements in collection shouldn't be equal");
        }

        [Test]
        public void Exception()
        {

        }
    }
}