using System;
using System.Collections.Generic;

//抽象クラスEmployeeを定義
abstract class Employee
{
    public string Id { get; set; }
    public string Name { get; set; }

    public Employee(string id, string name)
    {
        Id = id;
        Name = name;
    }
    public abstract double CalculateDailyWage(double hoursWorked);
}

//FullTimeEmployeeを定義
class FullTimeEmployee : Employee
{
    public FullTimeEmployee(string id, string name) : base(id, name)
    {
    }
    public override double CalculateDailyWage(double hoursWorked)
    {

    if (hoursWorked <= 8)
        {
           return hoursWorked  * 1250; // 時給1250円
        }
        else
        {
            return (8 * 1250) + ((hoursWorked - 8) * 1250 * 1.25); // 残業は時給の1.25倍
        }
    }
}

//ContractEmployeeを定義
class ContractEmployee : Employee
{
    public ContractEmployee (string id, string name) : base(id, name)
    {
    }

    public override double CalculateDailyWage(double hoursWorked)
    {
        return hoursWorked * 1000; //時給1000円
    }
}

//List<Employee>に社員を追加する
class EmployeeList
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>();

        employees.Add(new FullTimeEmployee("E001", "山田太郎"));
        employees.Add(new ContractEmployee("C001", "佐藤花子"));
        employees.Add(new FullTimeEmployee("E002", "鈴木一郎"));

        foreach (Employee emp in employees)
        {
            //労働時間は8時間か8.5時間
            double hours;

            if (emp.Id == "E001")
                hours = 8.5;
            else
                hours = 8;

            //給料計算
            double wage = emp.CalculateDailyWage(hours);

            //出力
            Console.WriteLine($"社員ID:{emp.Id},名前:{emp.Name} ,給料:{(int)wage} ");

        }
    }   
    
}