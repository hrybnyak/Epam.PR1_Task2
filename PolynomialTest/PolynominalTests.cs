using NUnit.Framework;
using System;
using System.Collections.Generic;
using Polynomial;

namespace Tests
{
    public class PolynominalTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PolynomialCreation()
        {
            List<double> list = new List<double> { 1, 2, 3, 4, 5 }; //5*x^4+4*x^3+3*x^2+2*x+1
            var pol = new Polynomial.Polynomial(list);
            Assert.IsNotNull(pol);
            Assert.IsTrue(pol.Function(1) == 15);
            Assert.IsTrue(pol.Function(0) == 1);
            Assert.IsTrue(pol.Function(-1) == 3);
        }
        [Test]
        public void PolynomialCloneTest()
        {
            List<double> list = new List<double> { 1, 2, 3, 4, 5 }; //5*x^4+4*x^3+3*x^2+2*x+1
            var pol = new Polynomial.Polynomial(list);
            var clone = (Polynomial.Polynomial)pol.Clone();
            Assert.AreNotSame(pol, clone);
            Assert.IsTrue(pol.Equals(clone));
        }
        [Test]
        public void PolynomialEqualsTest()
        {
            List<double> list = new List<double> { 1, 2, 3, 4, 5 };
            var pol = new Polynomial.Polynomial(list);
            var pol1 = new Polynomial.Polynomial(list);
            Assert.IsTrue(pol.Equals(pol1));
        }
        [Test]
        public void PolynomialDegreeTest()
        {
            List<double> list = new List<double> { 1, 2, 3, 4, 5 };
            var pol = new Polynomial.Polynomial(list);
            Assert.IsTrue(pol.Degree == 4);
        }
        [Test]
        public void PolynomialToStringTest()
        {
            List<double> list = new List<double> { 1, 2, 3 }; //3*x^2+2*x+1
            var pol = new Polynomial.Polynomial(list);
            var expected = "3 * (x^2) + 2 * x + 1";
            Assert.IsTrue(pol.ToString().Equals(expected));
        }
        [Test]
        public void PolynomialAddingTest()
        {
            List<double> list = new List<double> { 1, 2, 3 }; //3*x^2+2*x+1
            List<double> list1 = new List<double> { 0, 2, 4 }; //4*x^2+2*x
            List<double> list2 = new List<double> { 6, 11 };
            List<double> expectedResult = new List<double>{ 1, 4, 7};//7*x^2 + 4*x + 1
            var pol = new Polynomial.Polynomial(list);
            var pol1 = new Polynomial.Polynomial(list1);
            var result = pol + pol1;
            var result1 = pol1 + pol;
            var expected = new Polynomial.Polynomial(expectedResult);
            Assert.IsTrue(result.Equals(expected));
            Assert.IsTrue(result.Equals(result1));
            pol1 = new Polynomial.Polynomial(list2);
            result = pol + pol1;
            //3*x^2+13*x + 7
            expected[0] = 7; expected[1] = 13; expected[2] = 3;
            Assert.IsTrue(result.Equals(expected));
        }
        [Test]
        public void PolynomialSubtractionTest()
        {
            List<double> list = new List<double> { 1, 2, 3 }; //3*x^2+2*x+1
            List<double> list1 = new List<double> { 0, 2, 4 }; //4*x^2+2*x
            List<double> list2 = new List<double> { 6, 11 };
            List<double> expectedResult = new List<double> { 1, 0, -1 };
            var pol = new Polynomial.Polynomial(list);
            var pol1 = new Polynomial.Polynomial(list1);
            var result = pol - pol1;
            var expected = new Polynomial.Polynomial(expectedResult);
            Assert.IsTrue(result.Equals(expected));
            pol1 = new Polynomial.Polynomial(list2);
            result = pol - pol1;
            //3*x^2 - 9*x - 5
            expected[0] = -5; expected[1] = -9; expected[2] = 3;
            Assert.IsTrue(result.Equals(expected));
        }
        [Test]
        public void PolynomialMultiplicationTest()
        {
            List<double> list = new List<double> { 1, 2 }; //2*x+1
            List<double> list1 = new List<double> { 2, 4 }; //4*x+2
            List<double> expectedResult = new List<double>{2, 8, 8}; //8*x^2+8*x+2
            var pol = new Polynomial.Polynomial(list);
            var pol1 = new Polynomial.Polynomial(list1);
            var result = pol * pol1;
            var result1 = pol1 * pol;
            var expected = new Polynomial.Polynomial(expectedResult);
            Assert.IsTrue(result.Equals(expected));
            Assert.IsTrue(result.Equals(result1));
        }
        [Test]
        public void PolynomialMultiplicationByNumberTest()
        {
            List<double> list = new List<double> { 1, 2 }; //2*x+1
            List<double> expectedResult = new List<double> { 2, 4 }; //4*x+2
            int number = 2;
            var pol = new Polynomial.Polynomial(list);
            var result = pol * number;
            var result1 = number * pol;
            var expected = new Polynomial.Polynomial(expectedResult);
            Assert.IsTrue(result.Equals(expected));
            Assert.IsTrue(result.Equals(result1));
        }
    }
}