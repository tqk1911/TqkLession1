using System.Runtime.CompilerServices;
using System;

namespace Bai1_QuanLySinhVien;
public class Student
{
    public static int TotalStudents { get; private set; }
    public string MaSinhVien { get; set; }
    public string HoTen { get; set; }
    public DateTime NgaySinh { get; set; }
    public string GioiTinh { get; set; }
    public string Email { get; set; }
    public string SoDienThoai { get; set; }
    public string NganhHoc { get; set; }
    public double DiemTrungBinh { get; set; }
    public string TrangThaiHocTap { get; set; }
    public Student(
        string maSinhVien,
        string hoTen,
        DateTime ngaySinh,
        string gioiTinh,
        string email,
        string soDienThoai,
        string nganhHoc,
        double diemTrungBinh,
        string trangThaiHocTap)
    {
        MaSinhVien = maSinhVien;
        HoTen = hoTen;
        NgaySinh = ngaySinh;
        GioiTinh = gioiTinh;
        Email = email;
        SoDienThoai = soDienThoai;
        NganhHoc = nganhHoc;
        DiemTrungBinh = diemTrungBinh;
        TrangThaiHocTap = trangThaiHocTap;
    }    
    public static void InscreaseTotal()
    {
        TotalStudents++;
    }
    public static void DecreaseTotal()
    {
        if (TotalStudents > 0)
        {
            TotalStudents--;
        }
    }
    public override string ToString()
    {
        return $"Mã SV: {MaSinhVien} | " +
               $"Họ tên: {HoTen} | " +
               $"Ngày sinh: {NgaySinh:dd/MM/yyyy} | " +
               $"Giới tính: {GioiTinh} | " +
               $"Email: {Email} | " +
               $"SĐT: {SoDienThoai} | " +
               $"Ngành: {NganhHoc} | " +
               $"ĐTB: {DiemTrungBinh:F2} | " +
               $"Trạng thái: {TrangThaiHocTap}";
    }
} 