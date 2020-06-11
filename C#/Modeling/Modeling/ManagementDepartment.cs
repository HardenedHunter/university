using System.Threading;
// ReSharper disable CommentTypo

namespace Modeling
{
    //Отдел домоуправления
    public abstract class ManagementDepartment
    {
        //В каждом отделе есть работник
        protected Employee Employee;

        //и соответствующий ему поток
        protected Thread EmployeeThread;

        //Указатель на следующий отдел в цепочке
        protected ManagementDepartment Next;

        /// <summary>
        /// Метод для связывания двух отделов
        /// </summary>
        /// <param name="department">Новый отдел</param>
        /// <returns>Последний добавленный отдел</returns>
        public ManagementDepartment SetNext(ManagementDepartment department)
        {
            Next = department;
            return department;
        }

        /// <summary>
        /// Может ли отделение обработать поступающую заявку
        /// </summary>
        /// <param name="request">Заявка</param>
        /// <returns>Может ли отделение обработать поступающую заявку</returns>
        protected abstract bool CanHandle(Request request);

        /// <summary>
        /// Обработка заявки
        /// </summary>
        /// <param name="request">Поступающая заявка</param>
        /// <returns></returns>
        public virtual bool HandleRequest(Request request)
        {
            //Если этот отдел не может обработать заявку, отправить в следующий
            if (!CanHandle(request))
                return Next != null && Next.HandleRequest(request);

            //Если поток всё ещё работает над предыдущей заявкой,
            //обработка заявки пока невозможна
            if (EmployeeThread != null && EmployeeThread.IsAlive)
                return false;

            //Иначе поток начинает работу над заявкой
            EmployeeThread = new Thread(() => Employee.Process(request));
            EmployeeThread.Start();
            return true;
        }
    }
}