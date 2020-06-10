using System;
using System.Threading;

namespace Modeling
{
    public class Presenter
    {
        private readonly IView _view;

        private readonly SynchronizationContext _context;

        public Presenter(IView view)
        {
            _view = view;
            _context = _view.Context;
            var management = new HouseManagement();
            management.Manage(_context);
        }

        private void Render()
        {
            
        }

        ~Presenter()
        {
            Environment.Exit(0);
        }
    }
}