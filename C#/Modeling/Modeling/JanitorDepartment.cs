// ReSharper disable CommentTypo
// ReSharper disable StringLiteralTypo

namespace Modeling
{
    //Отдел уборщиков
    public class JanitorDepartment : Department
    {
        public JanitorDepartment()
        {
            Employee = new Janitor("Евгений");
            LinkEvents();
        }

        protected override bool CanHandle(Request request)
        {
            return request is JanitorRequest;
        }

        protected override Employee CreateEmployee(string name)
        {
            return new Janitor(name);
        }
    }
}