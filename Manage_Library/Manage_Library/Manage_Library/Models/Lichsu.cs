using System;
using System.Collections.Generic;

namespace Manage_Library.Models;

public partial class Lichsu
{
    public string MaTh { get; set; } = null!;

    public string? TenSach { get; set; }

    public DateTime? NgayMuon { get; set; }

    public string? MaDg { get; set; }

    public virtual Nguoidung? MaDgNavigation { get; set; }
}
