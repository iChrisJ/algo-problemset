using System;
using System.Collections.Generic;

namespace graph
{
    public class Graph
    {
        public IList<char> Vertexes;
        public int[,] Edges;

        public void BFS(Graph graph)
        {
            Queue<int> queue = new Queue<int>();
            bool[] visited = new bool[graph.Vertexes.Count];

            for (int i = 0; i < graph.Edges.GetLength(0); i++)
            {
                if (!visited[i])
                {
                    queue.Enqueue(i);
                    visited[i] = true;
                    while (queue.Count > 0)
                    {
                        int front = queue.Dequeue();
                        Console.Write($"{graph.Vertexes[front]} -> ");
                        for (int j = 0; j < graph.Edges.GetLength(1); j++)
                        {
                            if (graph.Edges[front, j] == 1 && !visited[j])
                            {
                                queue.Enqueue(j);
                                visited[j] = true;
                            }
                        }
                    }
                }
            }
            Console.WriteLine("End");
        }

        public void DFS(Graph graph)
        {
            Stack<int> stack = new Stack<int>();
            bool[] visited = new bool[graph.Vertexes.Count];

            for (int i = 0; i < graph.Edges.GetLength(0); i++)
            {
                if (!visited[i])
                {
                    stack.Push(i);
                    visited[i] = true;
                    Console.Write($"{graph.Vertexes[i]} -> ");
                    while (stack.Count > 0)
                    {
                        int top = stack.Pop();
                        for (int j = 0; j < graph.Edges.GetLength(1); j++)
                        {
                            if (graph.Edges[top, j] == 1 && !visited[j])
                            {
                                stack.Push(top);
                                stack.Push(j);
                                visited[j] = true;
                                Console.Write($"{graph.Vertexes[j]} -> ");
                                break;
                            }
                        }
                    }
                }
            }
            Console.WriteLine("End");
        }

        public IList<char> TopologySort(Graph graph)
        {
            int[] inDegree = new int[graph.Vertexes.Count];
            for (int i = 0; i < graph.Edges.GetLength(0); i++)
            {
                for (int j = 0; j < graph.Edges.GetLength(1); j++)
                {
                    if (graph.Edges[i, j] == 1)
                        inDegree[j]++;
                }
            }
            int[,] d = new int[,] { { 0, 1 }, { -1, 0 }, { 0, -1 }, { 1, 0 } };

            List<int> ans = new List<int>();
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < inDegree.Length; i++)
            {
                if (inDegree[i] == 0)
                    queue.Enqueue(i);
            }

            IList<char> res = new List<char>();
            while (queue.Count > 0)
            {
                int front = queue.Dequeue();
                res.Add(graph.Vertexes[front]);

                for (int i = 0; i < graph.Edges.GetLength(1); i++)
                {
                    if (graph.Edges[front, i] == 1)
                    {
                        inDegree[i] -= 1;
                        if (inDegree[i] == 0)
                            queue.Enqueue(i);
                    }
                }
            }
            return res;
        }

        public static void Main_tmp()
        {
            Graph graph = new Graph();
            graph.Vertexes = new List<char> { 'A', 'B', 'C', 'D', 'E' };
            graph.Edges = new int[,]
            {
               {0, 0, 1, 1, 0},
               {0, 0, 1, 0, 0},
               {0, 0, 0, 1, 1},
               {0, 0, 0, 0, 1},
               {0, 0, 0, 0, 0}
            };

            graph.TopologySort(graph);
        }
    }
}