using System.Text.RegularExpressions;
namespace Bai1_QuanLySinhVien;

public static class StudentValidator
{
    public static bool IsValidMaSinhVien( string maSinhVien)
    {
        return !string.IsNullOrWhiteSpace(maSinhVien);
    }
    public static bool IsValidHoTen(string hoTen)
    {
        return !string.IsNullOrWhiteSpace(hoTen);
    }
    public static bool IsValidDiem(double diem)
    {
        return diem >= 0 && diem <= 10;
    }
    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return false;
        }
        string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, pattern);
    }
}