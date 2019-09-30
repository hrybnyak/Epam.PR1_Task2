using System;
using System.Collections.Generic;
using System.Text;
namespace Polynomial
{
    public class Polynomial:
        ICloneable, IEquatable<Polynomial>
    {
        public List<double> Coefficients { get; }
        public double Function (double number)
        {
            try
            {
                if (this == null) throw new ArgumentNullException("This polynomial is empty");
                else
                {
                    double result = 0.0;
                    for (int i = 0; i < Coefficients.Count; i++)
                    {
                        result += Math.Pow(number, i) * Coefficients[i];
                    }
                    return result;
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            catch (Exception)
            {
                Console.WriteLine("Couldn't calculate function result");
                return 0;
            }
        }
        public object Clone() => new Polynomial(this.Coefficients);
        public override string ToString()
        {
            try
            {
                if (this == null)
                {
                    throw new ArgumentNullException("This polynomial is empty");
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = Degree; i >= 0; i--)
                    {
                        if (i == 0)
                        {
                            sb.Append($"{this[i]}");
                        }
                        else if (i == 1)
                        {
                            sb.Append($"{this[i]} * x + ");
                        }
                        else
                        {
                            sb.Append($"{this[i]} * (x^{i}) + ");
                        }
                    }

                    return sb.ToString();
                }
                
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex);
                return null;
            }
            catch (Exception)
            {
                Console.WriteLine("Couldn't convert to string");
                return null;
            }
        }
        public bool Equals(Polynomial other)
        {
            try
            {
                if (other.Coefficients.Count != this.Coefficients.Count)
                {
                    return false;
                }
                else
                {
                    for (int i = 0; i < Coefficients.Count; i++)
                    {
                        if (this[i] != other[i])
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Can't compare this polynomials");
                return false;
            }
        }
        public Polynomial(List<double> coef)
        {
            Coefficients = new List<double>(coef);
        }
        public double this[int i]
        {
            get
            {
                return this.Coefficients[i];
            }
            set
            {
                Coefficients[i] = value;
            }
        }
        public int Degree => Coefficients.Count - 1;
        public static Polynomial operator +(Polynomial left, Polynomial right)
        {
            try
            {
                if (left == null || right == null)
                {
                    throw new ArgumentNullException("One or both Polynomials are empty");
                }
                else
                {
                    List<double> result = new List<double>();
                    if (left.Degree >= right.Degree)
                    {
                        for (int i = 0; i <= right.Degree; i++)
                        {
                            result.Add(left[i] + right[i]);
                        }
                        for (int i = right.Degree+1; i <= left.Degree; i++)
                        {
                            result.Add(left[i]);
                        }
                        return new Polynomial(result);
                    }
                    else
                    {
                        for (int i = 0; i <= left.Degree; i++)
                        {
                            result.Add(left[i] + right[i]);
                        }
                        for (int i = left.Degree+1; i <= right.Degree; i++)
                        {
                            result.Add(right[i]);
                        }
                        return new Polynomial(result);
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            catch(Exception)
            {
                Console.WriteLine("Couldn't add polynomials");
                return null;
            }
        }
        public static Polynomial operator -(Polynomial left, Polynomial right)
        {
            try
            {
                if (left == null || right == null)
                {
                    throw new ArgumentNullException("One or both polynomials are empty");
                }
                else
                {
                    List<double> result = new List<double>();
                    if (left.Degree >= right.Degree)
                    {
                        for (int i = 0; i <= right.Degree; i++)
                        {
                            result.Add(left[i] - right[i]);
                        }
                        for (int i = right.Degree+1; i <= left.Degree; i++)
                        {
                            result.Add(left[i]);
                        }
                        return new Polynomial(result);
                    }
                    else
                    {
                        for (int i = 0; i <= left.Degree; i++)
                        {
                            result.Add(left[i] + right[i]);
                        }
                        for (int i = left.Degree+1; i <= right.Degree+1; i++)
                        {
                            result.Add(-right[i]);
                        }
                        return new Polynomial(result);
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            catch (Exception)
            {
                Console.WriteLine("Couldn't substract polynomial");
                return null;
            }
        }
        public static Polynomial operator *(Polynomial left, int number)
        {
            try
            {
                if (left == null)
                {
                    throw new ArgumentNullException("The polynomial is empty");
                }
                else
                {
                    List<double> result = new List<double>();
                    for (int i = 0; i <= left.Degree; i++)
                        {
                            result.Add(left[i] * number);
                        }
                    return new Polynomial(result);
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            catch (Exception)
            {
                Console.WriteLine("Couldn't multiply polynomial by number");
                return null;
            }
        }
        public static Polynomial operator *(int number, Polynomial left) => left * number;
        public static Polynomial operator *(Polynomial left, double number)
        {
            try
            {
                if (left == null)
                {
                    throw new ArgumentNullException("The polynomial is empty");
                }
                else
                {
                    List<double> result = new List<double>();
                    for (int i = 0; i <= left.Degree; i++)
                    {
                        result.Add(left[i] * number);
                    }
                    return new Polynomial(result);
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            catch (Exception)
            {
                Console.WriteLine("Couldn't multiply polynomial by number");
                return null;
            }
        }
        public static Polynomial operator *(double number, Polynomial left) => left * number;
        public static Polynomial operator *(Polynomial left, Polynomial right)
        {
            try
            {
                if (left == null || right == null)
                {
                    throw new ArgumentNullException("One or both Polynomials are empty");
                }
                else
                {
                    List<double> result = new List<double>();
                    int max = left.Degree + right.Degree + 1;
                    for (int i = 0; i<max; i++)
                    {
                        result.Add(0.0);
                    }
                    for (int i = left.Degree; i>=0; i--)
                    {
                        for (int j = right.Degree; j>=0; j--)
                        {
                            result[i + j] += left[i] * right[j];
                        }
                    }
                    return new Polynomial(result);
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            catch (Exception)
            {
                Console.WriteLine("Couldn't multiply polynomials");
                return null;
            }
        }
    }
}
