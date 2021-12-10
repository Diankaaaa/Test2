using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    public class Program
    {
        public class Graph<T>
        {
            public Graph() { }
            public Graph(IEnumerable<T> vertices, IEnumerable<Tuple<T, T>> edges)
            {
                foreach (var vertex in vertices)
                    AddVertex(vertex);

                foreach (var edge in edges)
                    AddEdge(edge);
            }

            public Dictionary<T, HashSet<T>> AdjacencyList { get; } = new Dictionary<T, HashSet<T>>();

            public void AddVertex(T vertex)
            {
                AdjacencyList[vertex] = new HashSet<T>();
            }

            public void AddEdge(Tuple<T, T> edge)
            {
                if (AdjacencyList.ContainsKey(edge.Item1) && AdjacencyList.ContainsKey(edge.Item2))
                {
                    AdjacencyList[edge.Item1].Add(edge.Item2);
                    AdjacencyList[edge.Item2].Add(edge.Item1);
                }
            }
        }



        public class Algorithms
        {
            public HashSet<T> BFS<T>(Graph<T> graph, T start)
            {
                var visited = new HashSet<T>();

                if (!graph.AdjacencyList.ContainsKey(start))
                    return visited;

                var queue = new Queue<T>();
                queue.Enqueue(start);

                while (queue.Count > 0)
                {
                    var vertex = queue.Dequeue();

                    if (visited.Contains(vertex))
                        continue;

                    visited.Add(vertex);

                    foreach (var neighbor in graph.AdjacencyList[vertex])
                        if (!visited.Contains(neighbor))
                            queue.Enqueue(neighbor);
                }

                return visited;
            }
        }



        public static void Main(string[] args)
        {
            var vertices = new[] { 1, 2, 3, 4, 5, 6, 7, 0 };
            var edges = new[]{Tuple.Create(1,0), Tuple.Create(0,3),
                Tuple.Create(0,4), Tuple.Create(2,4), Tuple.Create(6,2),
                Tuple.Create(6,5), Tuple.Create(5,1), Tuple.Create(5,7)};

            var graph = new Graph<int>(vertices, edges);
            var algorithms = new Algorithms();

            Console.WriteLine(string.Join(", ", algorithms.BFS(graph, 6)));
            Console.ReadKey();
        }
    }
}

