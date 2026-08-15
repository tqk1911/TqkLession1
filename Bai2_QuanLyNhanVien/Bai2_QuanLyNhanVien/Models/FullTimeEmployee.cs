using System;
namespace Bai2_QuanLyNhanVien.Models;
public class FullTimeEmployee : Employee
{
    public decimal PhuCap{get; set;}
    public FullTimeEmployee(
        string maNhanVien, 
        string hoTen,
        string phongBan,
        DateTime ngayVaoLam,
        decimal luongCoBan,
        decimal phuCap)
        : base(maNhanVien, hoTen, phongBan, ngayVaoLam, luongCoBan)
    {
        PhuCap= phuCap;
    }
    public override decimal CaculateSalary()
    {
        return LuongCoBan + PhuCap;
    }
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Phụ cấp : {PhuCap:N0}");
        Console.WriteLine($"Lương: {CaculateSalary():N0}");
    }
}