using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.DIP
{
    // Dependency Inversion Principle - Bağımlılığı Tersine Çevirme

    // Yüksek seviyeli modüllerin/sınıfların düşük seviyeli modüllere/sınıflara bağlı olmaması gerektiğini belirtir. Her ikisi de soyutlamalara dayanmalıdır. İkinci olarak, soyutlamalar ayrıntılara bağlı olmamalıdır. Detaylar soyutlamalara bağlı olmalıdır.

    // Gerçek zamanlı uygulamalar geliştirirken hatırlamanız gereken en önemli nokta, her zaman High-level modülü ve Low-level modülünü mümkün olduğunca gevşek bir şekilde bağlı tutmaya çalışmaktır.

    // Bir sınıf başka bir sınıfın tasarımını ve uygulamasını öğrendiğinde, bir sınıfta herhangi bir değişiklik yaparsak diğer sınıfı bozma riskini artırır. Bu nedenle, bu yüksek seviyeli ve düşük seviyeli modülleri/sınıfları mümkün olduğunca gevşek bir şekilde bağlı tutmalıyız. Bunun için ikisini de birbirini tanımak yerine soyutlamalara bağımlı hale getirmemiz gerekiyor.

    // ÖRNEK

    // 4 özelliği olan bir Employee sınıfı oluşturuyoruz
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }
    }

    // bir EmployeeDataAccess örneği oluşturmak için kullanılan bir oluşturucuya sahiptir.
    public class EmployeeBusinessLogic
    {
        // DIP'ten önce
        // EmployeeDataAccess _EmployeeDataAccess;

        // DIP'ten sonra
        IEmployeeDataAccess _EmployeeDataAccess;
        public EmployeeBusinessLogic()
        {
            _EmployeeDataAccess = DataAccessFactory.GetEmployeeDataAccessObj();
        }
        public Employee GetEmployeeDetails(int id)
        {
            return _EmployeeDataAccess.GetEmployeeDetails(id);
        }
    }

    public class DataAccessFactory
    {
        // DIP'ten önce
        // public static EmployeeDataAccess GetEmployeeDataAccessObj()
        // {
        //    return new EmployeeDataAccess();
        // }

        // DIP'ten sonra
        public static IEmployeeDataAccess GetEmployeeDataAccessObj()
        {
            return new EmployeeDataAccess();
        }
    }

    public class EmployeeDataAccess : IEmployeeDataAccess
    {
        public Employee GetEmployeeDetails(int id)
        {

            Employee emp = new Employee()
            {
                ID = id,
                Name = "Pranaya",
                Department = "IT",
                Salary = 10000
            };
            return emp;
        }
    }

    // EmployeeBusinessLogic EmployeeDataAccess sınıfının GetEmployeeDetails() yöntemini kullanır.Gerçek zamanlı olarak, EmployeeDataAccess sınıfında çalışanla ilgili birçok yöntem olacaktır.Bu nedenle, arayüzde GetEmployeeDetails(int id) yöntemini bildirmemiz gerekiyor.
    // -----------------------------------
    // Bu interfacei oluşturduktan sonra EmployeeDataAccess'e implement ediyoruz. ve EmployeeDataAccess yerine IEmployeeDataAccessi kullanıyoruz. Böylelikle
    public interface IEmployeeDataAccess
    {
        Employee GetEmployeeDetails(int id);
    }

    // Şimdi, EmployeeBusinessLogic ve EmployeeDataAccess sınıfları gevşek bağlı sınıflardır, çünkü EmployeeBusinessLogic somut EmployeeDataAccess sınıfına bağlı değildir, bunun yerine IEmployeeDataAccess interfacenin bir başvurusunu içerir. Şimdi, IEmployeeDataAccess'i farklı bir uygulama ile uygulayan başka bir sınıfı kolayca kullanabiliriz.


}
