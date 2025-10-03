using System;
using System.Collections.Generic;

namespace Manage_Library.Models;

public partial class Taikhoan
{
    public string Id { get; set; } = null!;

    public string? TaiKhoan1 { get; set; }

    public string? MatKhau { get; set; }

    public string? ThoiGianBatDau { get; set; }

    public string? ThoiGianKetThuc { get; set; }

    public string? TenNhanVien { get; set; }
}
