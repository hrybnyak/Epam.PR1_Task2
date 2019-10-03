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
        public object Clone() => new Polynomial(this.Coefficients);
        public override string ToString()
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
        public bool Equals(Polynomial other)
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
        public static Polynomial operator -(Polynomial left, Polynomial right)
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
        public static Polynomial operator *(Polynomial left, object number)
        {
            if (left == null)
                {
                    throw new ArgumentNullException("The polynomial is empty");
                }
                else
                {
                    double numb = (double)number;
                    List<double> result = new List<double>();
                    for (int i = 0; i <= left.Degree; i++)
                        {
                            result.Add(left[i] * numb);
                        }
                    return new Polynomial(result);
                }
        }
        public static Polynomial operator *(object number, Polynomial left) => left * number;
        public static Polynomial operator *(Polynomial left, Polynomial right)
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
            
    }
}
