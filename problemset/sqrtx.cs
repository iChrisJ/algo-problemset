namespace problemset.sqrtx
{
    public class Solution
    {
        public int MySqrt(int x)
        {
            if (x == 0)
                return 0;

            if (x <= 3)
                return 1;

            long le = 1, ri = x;
            long ans = le;
            while (le <= ri)
            {
                long mid = le + ((ri - le) >> 1);
                if (mid * mid <= (long)x)
                {
                    le = mid + 1;
                    ans = mid;
                }
                else
                    ri = mid - 1;
            }

            return (int)ans;
        }
    }
}