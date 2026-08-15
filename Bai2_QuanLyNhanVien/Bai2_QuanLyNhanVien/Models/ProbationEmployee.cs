using System;
namespace Bai2_QuanLyNhanVien.Models;
public class ProbationEmployee : Employee
{
    public ProbationEmployee(
        string maNhanVien,
        string hoTen,
        string phongBan,
        DateTime ngayVaoLam,
        decimal luongCoBan)
        : base(maNhanVien, hoTen, phongBan, ngayVaoLam, luongCoBan)
    {
    }
    public override decimal CaculateSalary()
    {
        return LuongCoBan*0.85m;
    }
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Nhân viên thử việc");
        Console.WriteLine($"Lương: {CaculateSalary():N0}");
    }
}