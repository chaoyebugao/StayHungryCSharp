using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.继承
{
    class Employee
    {

    }

    class Manager : Employee
    {

    }

    class Salary
    {
        public void SetSalary(Employee e)
        {
            Console.WriteLine("Employee被设置了薪水");
        }

    }

    class ManagerSalary : Salary
    {
        //此建议是使用Employee（然后用new替代）作为参数而不是派生类
        public void SetSalary(Manager e)
        {
            Console.WriteLine("Manager被设置了薪水");
        }
    }

    class TheSalaryProblem
    {
        public static void Exec()
        {
            ManagerSalary ms = new ManagerSalary();
            ms.SetSalary(new Employee());
            ms.SetSalary(new Manager());
        }
    }


}
