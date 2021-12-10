using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Test2;

namespace TestGraph
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var vertices = new[] { 1, 2, 3, 4, 5, 6, 7, 0 };
            var edges = new[]{Tuple.Create(1,0), Tuple.Create(0,3),
                Tuple.Create(0,4), Tuple.Create(2,4), Tuple.Create(6,2),
                Tuple.Create(6,5), Tuple.Create(5,1), Tuple.Create(5,7)};

            var graph = new Test2.Program.Graph<int>(vertices, edges);
            var algorithms = new Test2.Program.Algorithms();
            Assert.AreEqual("6, 2, 5, 4, 1, 7, 0, 3", string.Join(", ", algorithms.BFS(graph, 6)));
        }
    }
}
