using System;
using System.Collections.Generic;
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
            lock (request)
            {
                Thread.Sleep(3000);
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

    public class RequestCommittee
    {
        private readonly Queue<Request> _requests;

        public event Action<Request> RequestAdded;

        public RequestCommittee(Queue<Request> requests)
        {
            _requests = requests;
        }

        public void Generate(object context)
        {
            var rand = new Random(193);
            for (var i = 0;; i++)
            {
                GenerateOne(context as SynchronizationContext, i);
                Thread.Sleep(rand.Next(1000, 4000));
            }
        }

        private void GenerateOne(SynchronizationContext context, int requestId = 0)
        {
            lock (_requests)
            {
                var request = new PlumberRequest(requestId);
                _requests.Enqueue(request);
                context.Send(obj => RequestAdded?.Invoke(obj as Request), request);
            }
        }
    }


    public class PlumberDepartment : ManagementDepartment
    {
        public PlumberDepartment()
        {
            Employee = new Plumber("Mario");
        }

        protected override bool CanHandle(Request request)
        {
            return request is PlumberRequest;
        }
    }

    public class ElectricianDepartment : ManagementDepartment
    {
        public ElectricianDepartment()
        {
            Employee = new Electrician("Tesla");
        }

        protected override bool CanHandle(Request request)
        {
            return request is ElectricianRequest;
        }
    }

    public class JanitorDepartment : ManagementDepartment
    {
        public JanitorDepartment()
        {
            Employee = new Janitor("Johnny");
        }

        protected override bool CanHandle(Request request)
        {
            return request is JanitorRequest;
        }
    }

    public abstract class Request
    {
        private int _requestId;

        public int RequestId
        {
            get => _requestId;
            set
            {
                if (value < 0)
                    throw new ArgumentException("RequestId");
                _requestId = value;
            }
        }

        public bool IsCompleted { get; set; }

        protected Request(int requestId)
        {
            RequestId = requestId;
            IsCompleted = false;
        }
    }

    public class PlumberRequest : Request
    {
        public PlumberRequest(int requestId) : base(requestId)
        {
        }

        public override string ToString()
        {
            return $"Заявка №{RequestId} к сантехнику";
        }
    }

    public class ElectricianRequest : Request
    {
        public ElectricianRequest(int requestId) : base(requestId)
        {
        }

        public override string ToString()
        {
            return $"Заявка №{RequestId} к электрику";
        }
    }

    public class JanitorRequest : Request
    {
        public JanitorRequest(int requestId) : base(requestId)
        {
        }

        public override string ToString()
        {
            return $"Заявка №{RequestId} к уборщику";
        }
    }
}