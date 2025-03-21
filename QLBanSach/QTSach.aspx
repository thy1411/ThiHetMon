<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="QTSach.aspx.cs" Inherits="QLBanSach.QTSach" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NoiDung" runat="server">
    <h2>TRANG QUẢN TRỊ SÁCH</h2>
    <hr />
    <div class="row mb-2">
        <div class="col-md-6">
            <div class="form-inline">
                Tựa sách <asp:TextBox ID="txtTen" runat="server" placeholder="Nhập tựa sách cần tìm" CssClass="form-control ml-2" Width="300"></asp:TextBox>
                <asp:Button ID="btTraCuu" runat="server" Text="Tra cứu" CssClass="btn btn-info ml-2" OnClick="btTraCuu_Click" />
            </div>
        </div>
        <div class="col-md-6 text-right">
            <a href="ThemSach.aspx" class="btn btn-success">Thêm sách mới</a>
        </div>
    </div>

    <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" Visible="false" />

    <asp:GridView ID="gvSach" runat="server" AutoGenerateColumns="false" CssClass="table table-border table-hover"
    OnRowEditing="gvSach_RowEditing"
    OnRowCancelingEdit="gvSach_RowCancelingEdit"
    OnRowUpdating="gvSach_RowUpdating"
    OnRowDeleting="gvSach_RowDeleting"
    OnPageIndexChanging="gvSach_PageIndexChanging"
    DataKeyNames="MaSach" AllowPaging="true" PageSize="4">
        <Columns>
            <asp:BoundField DataField="TenSach" HeaderText="Tựa sách" />
            <asp:TemplateField HeaderText="Ảnh bìa">
                <ItemTemplate>
                    <img src="Bia_sach/<%# Eval("Hinh") %>" alt="Ảnh bìa" style="width: 100px; height: 150px; object-fit: cover;" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Dongia" HeaderText="Đơn giá" DataFormatString="{0:C}" />
            <asp:TemplateField HeaderText="Khuyến mãi">
                <ItemTemplate>
                    <%# Convert.ToBoolean(Eval("KhuyenMai")) ? "x" : "" %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="true" ButtonType="Button" EditText="Sửa" HeaderText="Chọn tác vụ" ShowDeleteButton="true" DeleteText="Xóa" />
        </Columns>
        <HeaderStyle BackColor="#E0FFFF" ForeColor="#00688B" />
        <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />
    </asp:GridView>
</asp:Content>
