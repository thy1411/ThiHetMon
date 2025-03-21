using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLBanSach.Models;

namespace QLBanSach
{
    public partial class QTSach : System.Web.UI.Page
    {
        SachDAO sachDAO = new SachDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        protected void gvSach_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSach.PageIndex = e.NewPageIndex;
            LoadData();
        }

        protected void gvSach_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvSach.EditIndex = e.NewEditIndex;
            LoadData();
        }

        protected void gvSach_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvSach.EditIndex = -1;
            LoadData();
        }

        protected void gvSach_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int maSach = Convert.ToInt32(gvSach.DataKeys[e.RowIndex].Value);
                TextBox txtTenSach = (TextBox)gvSach.Rows[e.RowIndex].FindControl("txtTenSach");
                TextBox txtGia = (TextBox)gvSach.Rows[e.RowIndex].FindControl("txtGia");
                CheckBox chkKhuyenMai = (CheckBox)gvSach.Rows[e.RowIndex].FindControl("chkKhuyenMai");

                Sach sach = new Sach
                {
                    MaSach = maSach,
                    TenSach = txtTenSach.Text,
                    Dongia = int.Parse(txtGia.Text),
                    KhuyenMai = chkKhuyenMai.Checked
                };

                sachDAO.Update(sach);

                gvSach.EditIndex = -1;
                LoadData();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Lỗi cập nhật: " + ex.Message;
                lblMessage.Visible = true;
            }
        }

        protected void gvSach_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int maSach = Convert.ToInt32(gvSach.DataKeys[e.RowIndex].Value);
                Sach sach = new Sach { MaSach = maSach };

                sachDAO.Delete(sach);

                LoadData();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Lỗi xoá: " + ex.Message;
                lblMessage.Visible = true;
            }
        }
        protected void btTraCuu_Click(object sender, EventArgs e)
        {
            try
            {
                string tenSach = txtTen.Text.Trim();
                var dsSach = sachDAO.laySachTheoTen(tenSach);

                if (dsSach.Count == 0)
                {
                    lblMessage.Text = "Không tìm thấy kết quả nào.";
                    lblMessage.Visible = true;
                    gvSach.DataSource = null;
                    gvSach.DataBind();
                }
                else
                {
                    lblMessage.Visible = false;
                    gvSach.DataSource = dsSach;
                    gvSach.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Lỗi tra cứu: " + ex.Message;
                lblMessage.Visible = true;
            }
        }
        private void LoadData()
        {
            gvSach.DataSource = sachDAO.getAll();
            gvSach.DataBind();
        }
    }
}
