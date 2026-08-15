using System;
using System.Collections.Generic;
using System.Linq;
using Bai2_QuanLyNhanVien.Models;
namespace Bai2_QuanLyNhanVien.Service;
public class EmployeeService
{
    private readonly List<Employee> employees = new();
    public void AddEmployee(Employee employee)
    {
        employees.Add(employee);
    }
    public List<Employee> GetAllEmployees()
    {
        return employees;
    }
    public decimal GetSaLary(Employee employee)
    {
        return employee.CaculateSalary();
    }
    public decimal GetToltalSalary()
    {
        return employees.Sum(e => e.CaculateSalary());
    }
    public Employee? GetHighestSalary()
    {
        return employees
            .OrderByDescending(e => e.CaculateSalary())
            .FirstOrDefault();
    }
    public List<Employee> SortBySalary()
    {
        return employees
            .OrderByDescending(e => e.CaculateSalary())
            .ToList();
    }
    public Dictionary<string, decimal> GetSalaryByDepartment()
    {
        return employees
            .GroupBy(e => e.PhongBan)
            .ToDictionary(
                group => group.Key,
                group => group.Sum(e => e.CaculateSalary())
            );
    }
    public List<Employee> GetOverThreeYear()
    {
        DateTime threeYearAgo = DateTime.Now.AddYears(-3);
        return employees
            .Where(e => e.NgayVaoLam <= threeYearAgo)
            .ToList();
    }
    public List<Employee> GetMonthlySalary()
    {
        return employees
            .OrderBy(e => e.MaNhanVien)
            .ToList();
    }
}