namespace problemset.valid_sudoku
{
    public class Solution
    {
        public bool IsValidSudoku(char[][] board)
        {
            bool[,] rows = new bool[9, 9];
            bool[,] cols = new bool[9, 9];
            bool[,] buckets = new bool[9, 9];

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] != '.')
                    {
                        int bucketNum = 3 * (i / 3) + (j / 3);
                        int digit = (board[i][j] - '0') - 1;
                        if (rows[i, digit] || cols[j, digit] || buckets[bucketNum, digit])
                            return false;
                        else
                        {
                            rows[i, digit] = true;
                            cols[j, digit] = true;
                            buckets[bucketNum, digit] = true;
                        }
                    }
                }
            }
            return true;
        }
    }
}