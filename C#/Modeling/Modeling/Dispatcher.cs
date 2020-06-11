﻿using System;
using System.Collections.Generic;
using System.Threading;
// ReSharper disable CommentTypo

namespace Modeling
{
    //Диспетчер домоуправления
    public class Dispatcher : Employee
    {
        //Отделы домоуправления
        private readonly ManagementDepartment _departments;

        //Очередь заявок населения
        private readonly Queue<Request> _requests;

        public event Action<Request> RequestProcessed;

        public Dispatcher(string name, ManagementDepartment departments, Queue<Request> requests) : base(name)
        {
            _departments = departments;
            _requests = requests;
        }

        /// <summary>
        /// Обработка заявок.
        /// </summary>
        /// <param name="context">Контекст синхронизации потоков</param>
        public void Manage(object context)
        {
            var rand = new Random(83);
            while (true)
            {
                CheckRequests(context as SynchronizationContext);
                Thread.Sleep(rand.Next(1000, 4000));
            }
        }

        /// <summary>
        /// Один проход обработки. Диспетчер блокирует очередь от других
        /// потоков на время просмотра заявок.
        /// </summary>
        /// <param name="context"></param>
        private void CheckRequests(SynchronizationContext context)
        {
            lock (_requests)
            {
                //Если очередь заявок пуста, дополнительные действия не требуются
                if (_requests.Count == 0) return;
                
                //Иначе достаём из очереди заявку и отправляем её на обработку в отделения
                var request = _requests.Dequeue();
                if (_departments.HandleRequest(request))
                    context.Send(obj => RequestProcessed?.Invoke(obj as Request), request);
                else
                    //Если обработать не получилось (соответствующее заявке отделение занято),
                    //заявка уходит обратно в очередь
                    _requests.Enqueue(request);
            }
        }
    }
}