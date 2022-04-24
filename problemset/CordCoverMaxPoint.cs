namespace problemset.CordCoverMaxPoint
{
    using System;

    public class CordCoverMaxPoint
    {
        #region Binary Search

        public static int MaxPints(int[] arr, int len)
        {
            if (arr == null || arr.Length == 0 || len <= 0)
                return 0;

            int ans = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                int nearest = NearestIndex(arr, i, arr[i] - len);
                ans = Math.Max(ans, i - nearest + 1);
            }
            return ans;
        }

        private static int NearestIndex(int[] arr, int ri, int val)
        {
            int le = 0;
            int ans = ri;
            while (le <= ri)
            {
                int mid = le + ((ri - le) >> 1);
                if (arr[mid] >= val)
                {
                    ans = mid;
                    ri = mid - 1;
                }
                else
                    le = mid + 1;
            }
            return ans;
        }

        #endregion

        #region Sliding Window

        public static int MaxPints2(int[] arr, int len)
        {
            if (arr == null || arr.Length == 0 || len <= 0)
                return 0;

            int l = 0, r = 0;
            int ans = 0;
            while (l < arr.Length)
            {
                while (r < arr.Length && arr[r] - arr[l] <= len)
                    r++;
                ans = Math.Max(ans, r - l + 1);
                l++;
            }
            return ans;
        }

        #endregion

    }
}