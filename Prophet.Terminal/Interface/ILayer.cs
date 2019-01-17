using System;

namespace Prophet.Terminal.Interface
{
    public interface ILayer
    {
        Atom[,] GetState();
    }
}