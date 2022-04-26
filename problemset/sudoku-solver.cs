namespace problemset.sudoku_solver
{
    public class Solution
    {
        public void SolveSudoku(char[][] board)
        {
            bool[,] rows = new bool[9, 10];
            bool[,] cols = new bool[9, 10];
            bool[,] buckets = new bool[9, 10];

            InitGrid(board, rows, cols, buckets);
            DFS(board, rows, cols, buckets, 0, 0);
        }

        private void InitGrid(char[][] board, bool[,] rows, bool[,] cols, bool[,] buckets)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] != '.')
                    {
                        int digit = board[i][j] - '0';
                        int number = 3 * (i / 3) + (j / 3);
                        rows[i, digit] = true;
                        cols[j, digit] = true;
                        buckets[number, digit] = true;
                    }
                }
            }
        }

        private bool DFS(char[][] board, bool[,] rows, bool[,] cols, bool[,] buckets, int i, int j)
        {
            if (i == 9)
                return true;

            int nexti = j == 8 ? i + 1 : i;
            int nextj = j == 8 ? 0 : j + 1;

            if (board[i][j] != '.')
                return DFS(board, rows, cols, buckets, nexti, nextj);
            else
            {
                for (int k = 1; k <= 9; k++)
                {
                    int number = 3 * (i / 3) + (j / 3);
                    if (!rows[i, k] && !cols[j, k] && !buckets[number, k])
                    {
                        board[i][j] = (char)(k + '0');
                        rows[i, k] = true;
                        cols[j, k] = true;
                        buckets[number, k] = true;
                        if (DFS(board, rows, cols, buckets, nexti, nextj))
                            return true;
                        board[i][j] = '.';
                        rows[i, k] = false;
                        cols[j, k] = false;
                        buckets[number, k] = false;
                    }
                }
            }
            return false;
        }
    }
}