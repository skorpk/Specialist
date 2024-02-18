using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab1_18_BinrayBalancedTree
{
    public class TreeNode
    {

        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public int Weight { get; set; }

    }

    internal class Program
    {
        static Random rnd = new Random();
        static long total;

        public static void CreateRandomTree(TreeNode node, int level)
        {
            node.Left = new TreeNode();
            node.Right = new TreeNode();
            node.Weight = rnd.Next(100);
            total += node.Weight;
            level--;
            if (level == 0)
            {
                node.Left.Weight = rnd.Next(100);
                node.Right.Weight = rnd.Next(100);
                total += node.Left.Weight;
                total += node.Right.Weight;
                return;
            }
            CreateRandomTree(node.Left, level);
            CreateRandomTree(node.Right, level);
        }

        /// <summary>
        /// Считаем вес
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static long weightTree(TreeNode root)
        {
            return
                (long)root.Weight +
                (root.Left != null ? weightTree(root.Left) : 0) +
                (root.Right != null ? weightTree(root.Right) : 0);

        }

        public static async Task<long> weightTreeAsync(TreeNode root, int depthTree = 8)
        {
                if(depthTree <= 0) 
                    return weightTree(root);
                int levelNew = depthTree - 1;

                return
                (long)root.Weight + (root.Left != null ? await weightTreeAsync(root.Left, levelNew) : 0) + (root.Right != null ? await weightTreeAsync(root.Right, levelNew) : 0);

        }

        static void Main(string[] args)
        {
            //При 27 ошибка OutOfMemory
            int treeLevel = 25; // 2^(n+1)-1

            Stopwatch tc = new Stopwatch();
            tc.Start();
            Console.WriteLine($"Starting tree creation with depth {treeLevel}...");
            TreeNode root = new TreeNode();
            CreateRandomTree(root, treeLevel);
            tc.Stop();
            Console.WriteLine($"Tree created with total weight: {total}. Created {tc.ElapsedMilliseconds}");

            
            Stopwatch ts = new Stopwatch();
            ts.Start();
            long r1 = weightTree(root);
            ts.Stop();
            Console.WriteLine($"Single weight: {r1} Time {ts.ElapsedMilliseconds}");

            ThreadPool.SetMinThreads(32, 32);
            ThreadPool.SetMaxThreads(64, 64);
            Stopwatch ta = new Stopwatch();
            ta.Start();
            long r2 = weightTreeAsync(root).Result;
            ta.Stop();
            Console.WriteLine($"Multy weight: {r2} Time {ta.ElapsedMilliseconds}");
        }
    }
}
