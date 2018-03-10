using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace graph_toanroirac
{
    class GraphData
    {
        public List<Point> NodeLocations;
        public Graph graph;
        public bool IsUndirectedGraph
        {
            get { return graph.IsUndirected; }
            set { graph.IsUndirected = value; }
        }

        public GraphData()
        {
            NodeLocations = new List<Point>();
            graph = new Graph();
        }
        public void SaveData(string filematrix, string filePoint)
        {
            graph.WriteFIle(filematrix);
            using (StreamWriter sw = new StreamWriter(filePoint))
            {
                foreach (Point item in NodeLocations)
                {
                    sw.WriteLine(item.ToString());
                }
            }
        }
        public void LoadData(string filematrix, string filePoint)
        {
            graph.ReadFile(filematrix);
            IsUndirectedGraph = graph.IsUndirected;
            if (File.Exists(filePoint))
            {
                using (StreamReader sd = new StreamReader(filePoint))
                {
                    while (!sd.EndOfStream)
                    {
                        string line = sd.ReadLine();
                        Point point = new Point();
                        point.X = int.Parse(line.Substring(line.IndexOf("X=") + 2, line.IndexOf(",") - line.IndexOf("X=") - 2));
                        point.Y = int.Parse(line.Substring(line.IndexOf("Y=") + 2, line.IndexOf("}") - line.IndexOf("Y=") - 2));
                        NodeLocations.Add(point);
                    }

                }
            }

        }
    }
}
