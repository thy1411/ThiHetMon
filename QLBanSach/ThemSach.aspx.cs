using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLBanSach.Models;

namespace QLBanSach
{
    public partial class ThemSach : System.Web.UI.Page
    {
        SachDAO sachDAO = new SachDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ChuDeDAO chuDeDAO = new ChuDeDAO();
                ddlChuDe.DataSource = chuDeDAO.getAll();
                ddlChuDe.DataTextField = "TenCD";
                ddlChuDe.DataValueField = "MaCD";
                ddlChuDe.DataBind();
            }
        }

        protected void btXuLy_Click(object sender, EventArgs e)
        {
            try
            {
                int macd = int.Parse(ddlChuDe.SelectedValue);
                string tensach = txtTen.Text;
                int dongia = int.Parse(txtDonGia.Text);
                bool khuyenmai = chkKhuyenMai.Checked;
                DateTime ngayCapNhat = DateTime.Now;

                // Xử lý upload file ảnh
                string hinh = FHinh.FileName;
                string path = Server.MapPath("~/Bia_sach/") + hinh;
                FHinh.SaveAs(path);

                // Tạo đối tượng sách cần thêm
                Sach sach = new Sach
                {
                    TenSach = tensach,
                    Dongia = dongia,
                    MaCD = macd,
                    Hinh = hinh,
                    KhuyenMai = khuyenmai,
                    NgayCapNhat = ngayCapNhat
                };

                // Gọi phương thức từ lớp DAO để thêm vào CSDL
                sachDAO.Insert(sach);

                lbThongBao.Text = "Thao tác thêm sách thành công";
                lbThongBao.CssClass = "text-success";
            }
            catch (Exception ex)
            {
                lbThongBao.Text = "Thao tác thêm sách thất bại: " + ex.Message;
                lbThongBao.CssClass = "text-danger";
            }
        }
    }
}