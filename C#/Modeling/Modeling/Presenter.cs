using System;
using System.Threading;

namespace Modeling
{
    public class ContextProvider
    {
        private static ContextProvider _instance;

        private SynchronizationContext _context;

        public SynchronizationContext Context
        {
            get => _context;
            set => _context = value ?? throw new ArgumentNullException(nameof(value));
        }

        private static readonly object Lock = new object();

        public static ContextProvider GetInstance()
        {
            if (_instance == null)
                lock (Lock)
                    if (_instance == null)
                        _instance = new ContextProvider();
            return _instance;
        }
    }

    public class Presenter
    {
        private readonly IView _view;

        private readonly HouseManagement _management;

        public Presenter(IView view)
        {
            _view = view;
            _view.Start += OnStart;
            _management = new HouseManagement();
            _management.RequestAdded += _view.OnRequestAdded;
            _management.RequestProcessed += _view.OnRequestProcessed;
            _management.RequestPostponed += _view.OnRequestPostponed;
            _management.RequestFinished += _view.OnRequestFinished;
            _management.SimulationFinished += _view.OnSimulationFinished;
            ContextProvider.GetInstance().Context = SynchronizationContext.Current;
        }

        private void OnStart(int size)
        {
            _management.Manage(size);
        }

        ~Presenter()
        {
            Environment.Exit(0);
        }
    }
}