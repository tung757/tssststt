using System;
using System.Collections.Generic;

namespace Manage_Library.Models;

public partial class Nguoidung
{
    public string MaDg { get; set; } = null!;

    public string? TenNguoiDung { get; set; }

    public string? Username { get; set; }

    public string? Passw { get; set; }

    public string? SoDienThoai { get; set; }

    public string? DiaChi { get; set; }

    public string? Email { get; set; }

    public DateTime? NgaySinh { get; set; }

    public string? VaiTro { get; set; }

    public string? GioiTinh { get; set; }

    public virtual ICollection<Danhsachmuontra> Danhsachmuontras { get; set; } = new List<Danhsachmuontra>();

    public virtual ICollection<Lichsu> Lichsus { get; set; } = new List<Lichsu>();
}
