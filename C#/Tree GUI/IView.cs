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
        event EventHandler<EventArgs> SelectArray;
        event EventHandler<EventArgs> SelectLinked;
        event EventHandler<EventArgs> ChangeFactor;
        event EventHandler<EventArgs> SortByEven;
        event EventHandler<EventArgs> SortByOdd;
        event EventHandler<EventArgs> FillTestData;

        void DrawTree(Action<Graphics> draw);
        void DrawEmpty();

        string InputAdd { get; }
        string InputDelete { get; }
        string InputFactor { get; }
    }
}