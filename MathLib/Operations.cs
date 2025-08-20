namespace MathLib
{
    public static class Operations
    {
        public static double Add(double a, double b) => a + b;
        public static double Subtract(double a, double b) => a - b;
        public static double Multiply(double a, double b) => a * b;
        public static double Divide(double a, double b)
        {
            if (b == 0) throw new System.DivideByZeroException();
            return a / b;
        }
    }
}
