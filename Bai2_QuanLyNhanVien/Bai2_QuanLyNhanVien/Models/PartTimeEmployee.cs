using System;
namespace Bai2_QuanLyNhanVien.Models;
public class PartTimeEmployee : Employee
{
    public int SoGioLam {get; set;}
    public decimal DonGiaGio{get; set;}
    public PartTimeEmployee(
        string maNhanVien,
        string hoTen,
        string phongBan,
        DateTime ngayVaoLam,
        decimal luongCoBan,
        int soGioLam,
        decimal donGiaGio)
        : base(maNhanVien, hoTen, phongBan, ngayVaoLam, luongCoBan)
    {
        LuongCoBan  = luongCoBan;
        DonGiaGio = donGiaGio;
    }
    public override decimal CaculateSalary()
    {
        return SoGioLam*DonGiaGio;
    }
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Số giờ làm: {SoGioLam}");
        Console.WriteLine($"Đơn giá giờ: {DonGiaGio:N0}");
        Console.WriteLine($"Luong: {CaculateSalary():N0}");
    }
}