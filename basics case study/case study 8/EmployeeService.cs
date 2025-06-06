using case_study_8;
using System;
using System.Collections.Generic;

public class EmployeeService
{
    private List<Employee> employees = new List<Employee>();

    public void AddEmployee(Employee emp)
    {
        employees.Add(emp);
    }

    public List<Employee> GetAllEmployees()
    {
        return employees;
    }

    public Employee GetEmployeeById(int id)
    {
        return employees.Find(emp => emp.Id == id);
    }
}
