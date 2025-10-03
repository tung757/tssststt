using System;
using System.Collections.Generic;

namespace Manage_Library.Models;

public partial class Sach
{
    public string MaSach { get; set; } = null!;

    public string? TenSach { get; set; }

    public string? TacGia { get; set; }

    public string? NhaXuatBan { get; set; }

    public int? NamXuatBan { get; set; }

    public string? NgonNgu { get; set; }

    public string? TheLoai { get; set; }

    public string? AnhBia { get; set; }

    public int? SoLuongConLai { get; set; }

    public int? GiaTien { get; set; }

    public virtual ICollection<Danhsachmuontra> Danhsachmuontras { get; set; } = new List<Danhsachmuontra>();
}
