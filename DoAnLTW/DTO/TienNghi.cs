using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLTW.DTO
{
    public class TienNghi
    {
        private string tenTienNghi;
        private string hinhAnh;

        public TienNghi(string tenTienNghi, string hinhAnh)
        {
            this.tenTienNghi = tenTienNghi;
            this.hinhAnh = hinhAnh;
        }

        public string TenTienNghi { get => tenTienNghi; set => tenTienNghi = value; }
        public string HinhAnh { get => hinhAnh; set => hinhAnh = value; }
    }
}
