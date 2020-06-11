using System;
using System.Threading;

namespace Modeling
{
    public class Presenter
    {
        private readonly IView _view;

        private readonly HouseManagement _management;

        public Presenter(IView view)
        {
            _view = view;
            _view.Start += OnStart;
            _management = new HouseManagement();
            _management.RequestAdded += OnRequestAdded;
            _management.RequestProcessed += OnRequestProcessed;
        }

        private void OnStart(object sender, EventArgs e)
        {
            var context = _view.Context;
            _management.Manage(context);
        }

        private void OnRequestAdded(Request request)
        {
            _view.OnRequestAdded(request);
        }

        private void OnRequestProcessed(Request request)
        {
            _view.OnRequestProcessed(request);
        }

        ~Presenter()
        {
            Environment.Exit(0);
        }
    }
}