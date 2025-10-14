using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comedor.Marisco
{
    public class Comedor
    { 
        public double Add(double num1, double num2)
        { 
            return num1 + num2; 
        } 

        public double subtract (double num1, double num2)
        { 
            return num1 - num2; 

        }

        public double multiply(double num1, double num2)
        {
            return num1 * num2;

        }

        public double divide(double num1, double num2)
        {
            if (num2 == 0)

            {
                throw new ArgumentException("division by zero is not allowed.");
            }

            return num1 / num2;


        }


    }


}
