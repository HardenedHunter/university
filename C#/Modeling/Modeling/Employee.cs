using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;

// ReSharper disable CommentTypo

// ReSharper disable StringLiteralTypo

namespace Modeling
{
    public class Employee
    {
        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                if (value.Length == 0)
                    throw new ArgumentException("Имя не может быть пустым.");
                _name = value;
            }
        }

        public Employee(string name)
        {
            Name = name;
        }

        public virtual void Process(Request request)
        {
            Thread.Sleep(3000);
            lock (request)
            {
                request.IsCompleted = true;
            }
        }
    }

    public class Plumber : Employee
    {
        public Plumber(string name) : base(name)
        {
        }
    }

    public class Electrician : Employee
    {
        public Electrician(string name) : base(name)
        {
        }
    }

    public class Janitor : Employee
    {
        public Janitor(string name) : base(name)
        {
        }
    }

    public class Dispatcher : Employee
    {
        private readonly RequestHandler _handler;

        private readonly Queue<Request> _requests;

        public Dispatcher(string name, RequestHandler handler, Queue<Request> requests) : base(name)
        {
            _handler = handler;
            _requests = requests;
        }

        public void ManageRequests(object context)
        {
            while (true)
            {
                CheckRequests();
                Thread.Sleep(1000);
            }
        }

        private void CheckRequests()
        {
            lock (_requests)
            {
                if (_requests.Count > 0)
                {
                    var request = _requests.Dequeue();
                    if (!_handler.HandleRequest(request))
                        _requests.Enqueue(request);
                }
            }
        }
    }

    public class RequestGenerator
    {
        private readonly Queue<Request> _requests;

        public RequestGenerator(Queue<Request> requests)
        {
            _requests = requests;
        }

        public void GenerateRequests(object context)
        {
            while (true)
            {
                AddRequest();
                Thread.Sleep(1000);
            }
        }

        private void AddRequest()
        {
            lock (_requests)
            {
                _requests.Enqueue(new Request());
            }
        }
    }

    //Класс базового обработчика заявок
    public abstract class RequestHandler
    {
        protected Thread WorkerThread;
        protected Employee Employee;
        protected RequestHandler Next;

        //Метод для связывания двух обработчиков
        public RequestHandler SetNext(RequestHandler requestHandler)
        {
            Next = requestHandler;
            return requestHandler;
        }

        protected abstract bool CanHandle(Request request);

        public virtual bool HandleRequest(Request request)
        {
            if (!CanHandle(request))
                return Next != null && Next.HandleRequest(request);

            if (WorkerThread != null && WorkerThread.IsAlive)
                return false;

            WorkerThread = new Thread(() => Employee.Process(request));
            return true;
        }
    }

    public class PlumberHandler : RequestHandler
    {
        public PlumberHandler()
        {
            Employee = new Plumber("Mario");
        }

        protected override bool CanHandle(Request request)
        {
            return request is PlumberRequest;
        }
    }

    public class ElectricianHandler : RequestHandler
    {
        public ElectricianHandler()
        {
            Employee = new Electrician("Tesla");
        }

        protected override bool CanHandle(Request request)
        {
            return request is ElectricianRequest;
        }
    }

    public class JanitorHandler : RequestHandler
    {
        public JanitorHandler()
        {
            Employee = new Janitor("Bob");
        }

        protected override bool CanHandle(Request request)
        {
            return request is JanitorRequest;
        }
    }

    public class Request
    {
        public bool IsCompleted { get; set; }

        public Request()
        {
            IsCompleted = false;
        }
    }

    public class PlumberRequest : Request
    {
    }

    public class ElectricianRequest : Request
    {
    }

    public class JanitorRequest : Request
    {
    }

    public class HouseManagement
    {
        private readonly Dispatcher _dispatcher;
        private readonly RequestGenerator _generator;

        public HouseManagement()
        {
            var requests = new Queue<Request>();
            _generator = new RequestGenerator(requests);
            var requestChain = new PlumberHandler().SetNext(new ElectricianHandler()).SetNext(new JanitorHandler());
            _dispatcher = new Dispatcher("John Doe", requestChain, requests);
        }

        public void Manage(SynchronizationContext context)
        {
            var generatorThread = new Thread(_generator.GenerateRequests);
            var dispatcherThread = new Thread(_dispatcher.ManageRequests);
            generatorThread.Start(context);
            dispatcherThread.Start(context);
        }
    }
}