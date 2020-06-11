using System;
using System.Threading;

namespace Modeling
{
    public interface IView
    {
        SynchronizationContext Context { get; set; }

        event EventHandler<EventArgs> Start;
        event EventHandler<EventArgs> Stop;

        void OnRequestAdded(Request request);
        void OnRequestProcessed(Request request);
    }
}