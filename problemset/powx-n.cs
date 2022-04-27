namespace problemset.powx_n
{
    using System;
    public class Solution
    {
        public double MyPow(double x, int n)
        {
            if(x == 0)
                return 1;

            double t = x;
            double ans = 1;
            int pow = Math.Abs(n == int.MinValue ? n + 1 : n);
            while (pow != 0) 
            {
                if ((pow & 1) != 0)
                    ans *= t;

                t *= t;
                pow = pow >> 1;
            }

            if(n == int.MinValue)
                ans *= x;

            return n > 0 ? ans : (1 / ans);
        }
    }
}