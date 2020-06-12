// ReSharper disable StringLiteralTypo
// ReSharper disable CommentTypo

namespace Modeling
{
    //Отдел сантехников
    public class PlumberDepartment : Department
    {
        public PlumberDepartment()
        {
            Employee = new Plumber("Егор");
            LinkEvents();
        }

        protected override bool CanHandle(Request request)
        {
            return request is PlumberRequest;
        }

        protected override Employee CreateEmployee(string name)
        {
            return new Plumber(name);
        }
    }
}