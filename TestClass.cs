namespace SimpleCalculator
{
    public static class TestClass
    {
        public static int PlusMethod(int x, double y)
        {
            return x + (int)y;
        }

        public static double PlusMethod(double x, double y)
        {
            return x + y;
        }

        public static double PlusMethod(double x, double y, double z)
        {
            return x + y + z;
        }

        public static double PlusMethod(int x, double y, float z)
        {
            return x + y + z;
        }

        public static double PlusMethod(float x, int y, double z)
        {
            return x + y + z;
        }


    }
}