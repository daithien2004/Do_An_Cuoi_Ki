using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLTW.DTO
{
    public class Tinh
    {
        private string tenTinh;
        private string hinhAnh;

        public Tinh(string tenTinh, string hinhAnh)
        {
            this.TenTinh = tenTinh;
            this.HinhAnh = hinhAnh;
        }

        public string TenTinh { get => tenTinh; set => tenTinh = value; }
        public string HinhAnh { get => hinhAnh; set => hinhAnh = value; }
    }
}
