<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="XemSach.aspx.cs" Inherits="QLBanSach.XemSach" %>

<asp:Content ID="Content1" ContentPlaceHolderID="NoiDung" runat="server">
    <h3>Trang xem sách</h3>
    <hr />
    
    <div class="form-inline">
        Chọn chủ đề
        <asp:DropDownList ID="ddlChuDe" runat="server" DataSourceID="odsChuDe" DataTextField="TenCD" DataValueField="MaCD" CssClass="form-control" AutoPostBack="True">
        </asp:DropDownList>
    </div>

    <div class="row" style="margin-top: 10px">
        <asp:Repeater ID="rptSach" runat="server" DataSourceID="odsSach">
            <ItemTemplate>
                <div class="col-md-4 text-center">
                    <img src="Bia_sach/<%# Eval("Hinh") %>" style="width: 250px" alt="Ảnh bìa sách" />
                    <br />
                    <asp:Label ID="lbTen" runat="server" Text='<%# Eval("TenSach") %>'></asp:Label>  <br />
                    Giá bán: 
                    <asp:Label ID="lbGia" runat="server" ForeColor="#ff6600" Text='<%# Eval("Dongia","{0: #,##0} VNĐ") %>'></asp:Label>
                    <br />
                    <a href="DatMua.aspx?MaSach=<%# Eval("MaSach") %>" class="btn btn-primary">Đặt mua</a>
                    <a href="ChiTiet.aspx?MaSach=<%# Eval("MaSach") %>" class="btn btn-success">Xem chi tiết</a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <asp:ObjectDataSource ID="odsChuDe" runat="server"
        SelectMethod="getAll"
        TypeName="QLBanSach.Models.ChuDeDAO"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="odsSach" runat="server" SelectMethod="laySachTheoChuDe" TypeName="QLBanSach.Models.SachDAO">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlChuDe" Name="macd" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
