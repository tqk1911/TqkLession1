using System;
namespace Bai2_QuanLyNhanVien.Models;
public class SalesEmployee : Employee
{
    public decimal DoanhSo{get; set;}
    public decimal TyLeHoaHong{get; set;}
    public SalesEmployee(
        string maNhanVien,
        string hoTen,
        string phongBan, 
        DateTime ngayVaoLam,
        decimal luongCoBan,
        decimal doanhSo,
        decimal tyLeHoaHong)
        : base(maNhanVien, hoTen, phongBan, ngayVaoLam, luongCoBan)
    {
        DoanhSo = doanhSo;
        TyLeHoaHong = tyLeHoaHong;
    }

    public override decimal CaculateSalary()
    {
        return LuongCoBan+DoanhSo*TyLeHoaHong;
    }
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Doanh số: {DoanhSo:N0}");
        Console.WriteLine($"Tỷ lệ hoa hồng: {TyLeHoaHong:N0}");
        Console.WriteLine($"Lương: {CaculateSalary():N0}");
    }
}