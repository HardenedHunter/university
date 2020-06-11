using System;
using System.Collections.Generic;
using System.Threading;
// ReSharper disable CommentTypo
// ReSharper disable PrivateFieldCanBeConvertedToLocalVariable

namespace Modeling
{
    //Домоуправление
    public class HouseManagement
    {
        //Диспетчер, который обрабатывает поступающие заявки
        private readonly Dispatcher _dispatcher;
        
        //Комиссия по приёму заявок
        private readonly RequestCommittee _committee;
        
        //Очередь заявок населения на услуги ЖКХ
        private readonly Queue<Request> _requests;

        //Отделения домоуправления (паттерн "Цепочка Обязанностей")
        private readonly ManagementDepartment _departments;

        public event Action<Request> RequestAdded;
        public event Action<Request> RequestProcessed;

        public HouseManagement()
        {
            _requests = new Queue<Request>();
            _departments = CreateDepartmentChain();
            _committee = new RequestCommittee(_requests);
            _dispatcher = new Dispatcher("John Doe", _departments, _requests);

            _committee.RequestAdded += request => RequestAdded?.Invoke(request);
            _dispatcher.RequestProcessed += request => RequestProcessed?.Invoke(request);
        }

        /// <summary>
        /// Моделирование создания и обработки заявок
        /// </summary>
        /// <param name="context">Контекст синхронизации потоков</param>
        public void Manage(SynchronizationContext context)
        {
            var committeeThread = new Thread(_committee.Generate);
            var dispatcherThread = new Thread(_dispatcher.Manage);
            committeeThread.Start(context);
            dispatcherThread.Start(context);
        }

        /// <summary>
        /// Создание отделений домоуправления (паттерн "Цепочка Обязанностей")
        /// </summary>
        /// <returns>Начало цепочки</returns>
        private static ManagementDepartment CreateDepartmentChain()
        {
            var departmentChain = new PlumberDepartment();
            departmentChain.SetNext(new ElectricianDepartment()).SetNext(new JanitorDepartment());
            return departmentChain;
        }
    }
}