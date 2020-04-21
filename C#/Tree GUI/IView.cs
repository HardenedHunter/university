using System;
using System.Drawing;

namespace Tree_GUI
{
    public interface IView
    {
        event EventHandler<EventArgs> AddNode;
        event EventHandler<EventArgs> DeleteNode;
        event EventHandler<EventArgs> Clear;

        void DrawTree(Action<Graphics> draw);
       
        string InputAdd { get; }
        string InputDelete { get; }
    }
}