using System;
using System.Collections.Generic;

namespace QuanLyRaVao.Models;

public partial class Quyen
{
    public int MaQuyen { get; set; }

    public string Ten { get; set; } = null!;

    public string? ActionName { get; set; }

    public string? ControllerName { get; set; }

    public virtual ICollection<NhomQuyen> NhomQuyens { get; set; } = new List<NhomQuyen>();
}
