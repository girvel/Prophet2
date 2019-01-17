using System;
using System.Collections.Generic;
using System.Linq;

namespace Prophet.Terminal.Interface
{
    public class CompositionUi
    {
        public List<ILayer> Layers { get; set; } = new List<ILayer>();



        public void Display()
        {
            var data = Layers.Aggregate(new Atom[0, 0], (d, layer) => d.Overlay(layer.GetState()));
        
            Console.Clear();
            for (int y = 0; y < data.GetLength(1); y++)
            {
                for (int x = 0; x < data.GetLength(0); x++)
                {
                    Console.ForegroundColor = data[x, y].Foreground;
                    Console.BackgroundColor = data[x, y].Background;
                    Console.Write(data[x, y].Character);
                }
                
                Console.WriteLine();
            }
        }
    }
}