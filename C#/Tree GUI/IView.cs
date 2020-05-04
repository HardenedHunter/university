using System;
using System.Drawing;

namespace Tree_GUI
{
    public interface IView
    {
        event EventHandler<EventArgs> AddNode;
        event EventHandler<EventArgs> DeleteNode;
        event EventHandler<EventArgs> Clear;
        event EventHandler<EventArgs> Reload;

        void DrawTree(Action<Graphics> draw);
       
        string InputAdd { get; }
        string InputDelete { get; }
    }
}