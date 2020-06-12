// ReSharper disable StringLiteralTypo
// ReSharper disable CommentTypo

namespace Modeling
{
    //Отдел электриков
    public class ElectricianDepartment : Department
    {
        public ElectricianDepartment()
        {
            Employee = new Electrician("Михаил");
            LinkEvents();
        }

        protected override bool CanHandle(Request request)
        {
            return request is ElectricianRequest;
        }

        protected override Employee CreateEmployee(string name)
        {
            return new Electrician(name);
        }
    }
}