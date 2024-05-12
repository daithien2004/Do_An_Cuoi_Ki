using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnLTW.DTO;

namespace DoAnLTW
{
    public class XuLyChuoiTienNghi
    {
        public static string GetCheckedValuesAsString(ref CheckedListBox clbTienNghi)
        {

            string checkedValuesString = "";

            // Duyệt qua tất cả các mục trong CheckedListBox
            for (int i = 0; i < clbTienNghi.Items.Count; i++)
            {
                // Kiểm tra xem mục thứ i có được chọn không
                if (clbTienNghi.GetItemChecked(i))
                {
                    // Nếu được chọn, thêm giá trị của mục này vào chuỗi
                    checkedValuesString += clbTienNghi.Items[i].ToString() + ",";
                }
            }

            // Kiểm tra xem chuỗi có dài hơn 0 ký tự không
            if (!string.IsNullOrEmpty(checkedValuesString))
            {
                // Loại bỏ dấu phẩy cuối cùng nếu có
                checkedValuesString = checkedValuesString.Remove(checkedValuesString.Length - 1);
            }

            // Trả về chuỗi kết quả
            return checkedValuesString;
        }

        public static void CheckItemsFromString(ref string tienNghi, CheckedListBox clbTienNghi)
        {
            string[] fileArray = tienNghi.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < clbTienNghi.Items.Count; i++)
            {
                string itemName = clbTienNghi.Items[i].ToString();
                if (fileArray.Contains(itemName))
                {
                    clbTienNghi.SetItemChecked(i, true);
                }
            }
        }

    }
}
