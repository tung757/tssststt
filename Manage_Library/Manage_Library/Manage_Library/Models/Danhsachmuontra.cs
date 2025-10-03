using System;
using System.Collections.Generic;

namespace Manage_Library.Models;

public partial class Danhsachmuontra
{
    public string MaDg { get; set; } = null!;

    public string MaSach { get; set; } = null!;

    public string MaPhieu { get; set; } = null!;

    public string? GhiChu { get; set; }

    public int? SoLuong { get; set; }

    public DateTime? NgayMuon { get; set; }

    public DateTime? NgayTra { get; set; }

    public virtual Nguoidung MaDgNavigation { get; set; } = null!;

    public virtual Sach MaSachNavigation { get; set; } = null!;
}
