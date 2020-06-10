using System.Threading;

namespace Modeling
{
    public interface IView
    {
        SynchronizationContext Context { get; set; }
    }
}