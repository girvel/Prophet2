using System;
using System.Collections.Generic;
using System.Linq;

namespace Prophet.Terminal.Interface
{
    public class CompositionUi
    {
        public List<ILayer> Layers { get; set; } = new List<ILayer>();



        public CompositionUi()
        {
        }
        
        public CompositionUi(params ILayer[] layers)
        {
            Layers = layers.ToList();
        }

        public void Display()
        {
            var data = Layers.Aggregate(new Atom[0, 0], (d, layer) => d.Overlay(layer.GetState()));
        
            Console.Clear();
            for (int y = 0; y < Math.Min(data.GetLength(1), Console.WindowHeight - 1); y++)
            {
                for (int x = 0; x < Math.Min(data.GetLength(0), Console.BufferWidth - 1); x++)
                {
                    var c = data[x, y];

                    if (c == null)
                    {
                        Console.ResetColor();
                        Console.Write(' ');
                        continue;
                    }
                    
                    Console.ForegroundColor = c.Foreground;
                    Console.BackgroundColor = c.Background;
                    Console.Write(c.Character);
                }
                
                Console.WriteLine();
            }
        }
    }
}