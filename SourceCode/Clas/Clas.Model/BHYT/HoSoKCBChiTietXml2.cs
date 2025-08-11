using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Clas.Model.BHYT
{
    public class HoSoKCBChiTietXml2
    {
        public string Id { get; set; }
        public string MaLk { get; set; }
        [DisplayName("Số thứ tự")]
        public int Stt { get; set; }
        [DisplayName("Mã thuốc")]
        public string MaThuoc { get; set; }
        [DisplayName("Mã nhóm")]
        public string MaNhom { get; set; }
        [DisplayName("Tên thuốc")]
        public string TenThuoc { get; set; }
        [DisplayName("Đơn vị tính")]
        public string DonViTinh { get; set; }
        [DisplayName("Hàm Lượng")]
        public string HamLuong { get; set; }
        [DisplayName("Đường dùng")]
        public string DuongDung { get; set; }
        [DisplayName("Liều lượng")]
        public string LieuDung { get; set; }
        [DisplayName("Số dăng ký")]
        public string SoDangKy { get; set; }
        [DisplayName("Số lượng")]
        public float SoLuong { get; set; }
        [DisplayName("Đơn giá")]
        public float DonGia { get; set; }
        [DisplayName("Tỷ kệ thanh toán")]
        public float TyLe { get; set; }
        [DisplayName("Thành tiền")]
        public float ThanhTien { get; set; }
        [DisplayName("Mã khoa")]
        public string MaKhoa { get; set; }
        [DisplayName("Mã bác sĩ")]
        public string MaBacSi { get; set; }
        [DisplayName("Mã bệnh")]
        public string MaBenh { get; set; }
        [DisplayName("Mã phương thức thanh toán")]
        public string MaPttt { get; set; }

        public int CosokcbId { get; set; }
        public string TinhthanhId { get; set; }
        public int Trangthai { get; set; }
        public int HosoId { get; set; }
        public string Mieuta { get; set; }
        public string Status { get; set; }
        public string NgayYl { get; set; }
        public string ThuocId { get; set; }
        public string TNguonkhac { get; set; }
        public int Xml19324Id { get; set; }
        public string KygiamdinhId { get; set; }
        public string KyQT { get; set; }
        public string MaCskcb { get; set; }
    }
}
