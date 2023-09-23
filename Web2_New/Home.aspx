<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Web2_New.WebForm2" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <meta name="author" content="Bin-It">
    <meta property="og:description" content="Wellcome to my Website" />

    <title>Quản Lý Điện Thoại</title>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.2/css/all.css"
        integrity="sha384-oS3vJWv+0UjzBfQzYUhtDYW+Pj2yciDJxpsK1OYPAYjqT085Qq/1cq5FLXAZQ7Ay" crossorigin="anonymous">
    <!--===============================================================================================-->
    <link rel="stylesheet" href="./Assets/css/style.css">
    <!-- Latest compiled and minified CSS -->
    <!--===============================================================================================-->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">
    <!-- jQuery library -->
    <!--===============================================================================================-->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
    <!--===============================================================================================-->
    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
    <!--===============================================================================================-->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.min.css">
    <!--===============================================================================================-->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/2.1.2/sweetalert.min.js"></script>
    <!--===============================================================================================-->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto|Varela+Round|Open+Sans">
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
    <!--===============================================================================================-->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">

    <style>
        .custom-gridview {
            table-layout: fixed;
            width: 100%;
            border-collapse: collapse;
        }

            .custom-gridview th {
                padding: 15px;
                text-align: center;
                vertical-align: middle;
            }

            .custom-gridview td {
                padding: 5px;
                text-align: center;
                vertical-align: middle;
            }

            .custom-gridview th {
                background-color: #006699;
                color: white;
                font-weight: bold;
            }

            .custom-gridview tr:nth-child(even) {
                background-color: #F1F1F1;
            }

            .custom-gridview tr:nth-child(odd) {
                background-color: #FFFFFF;
            }

            .custom-gridview tr:hover {
                background-color: #669999;
                color: white;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!------Header------>
        <nav class="navbar navbar-default navbar-fixed-top">
            <div class="container-fluid">
                <div class="navbar-header">
                    <a class="navbar-brand" href=""><i class="fa fa-user-circle" aria-hidden="true"></i>QUẢN
                    LÝ ĐIỆN THOẠI</a>
                </div>
                <div class="collapse navbar-collapse">
                    <ul class="nav navbar-nav navbar-right">
                        <li>
                            <button runat="server" onserverclick="btnDataAll_Click" class="nv" type="button" data-toggle="tooltip" data-placement="top"
                                title="Tất Cả Danh Sách Sản Phẩm">
                                <i>Tất cả</i></button>
                        </li>
                        <li>
                            <button runat="server" onserverclick="btnDataApple_Click" class="nv" type="button" data-toggle="tooltip" data-placement="top"
                                title="Danh Sách Sản Phẩm Thương Hiệu iPhone">
                                <i>iPhone</i></button>
                        </li>
                        <li>
                            <button runat="server" onserverclick="btnDataSamsung_Click" class="nv" type="button" data-toggle="tooltip" data-placement="top"
                                title="Danh Sách Sản Phẩm Thương Hiệu SamSung">
                                <i>SamSung</i></button>
                        </li>
                        <li>
                            <button runat="server" onserverclick="btnDataOppo_Click" class="nv" type="button" data-toggle="tooltip" data-placement="top"
                                title="Danh Sách Sản Phẩm Thương Hiệu Oppo">
                                <i>Oppo</i></button>
                        </li>
                        <li>
                            <button runat="server" onserverclick="btnDataXiaomi_Click" class="nv" type="button" data-toggle="tooltip" data-placement="top"
                                title="Danh Sách Sản Phẩm Thương Hiệu Xiaomi">
                                <i>Xiaomi</i></button>
                        </li>
                        <li>
                            <button runat="server" onserverclick="btnDataHauwei_Click" class="nv" type="button" data-toggle="tooltip" data-placement="top"
                                title="Danh Sách Sản Phẩm Thương Hiệu Hauwei">
                                <i>Hauwei</i></button>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
        <!------Conntent------>
        <div class="container-fluid al" style="height: 10px">
            <br>
            <p><b>TÌM KIẾM SẢN PHẨM:</b></p>
            <input runat="server" type="text" id="txtSearch" placeholder="Nhập tên sản phẩm cần tìm...">
            <button runat="server" onserverclick="btnSearch_Click" style="float: right;" class="nv" type="button" data-toggle="tooltip" data-placement="top"
                title="In Danh Sách Sản Phẩm">
                <i>Tìm Kiếm</i></button>
            <br>
            <br>
            <br>
            <b>CHỨC NĂNG:</b><br>
            <button runat="server" onserverclick="btnAdd_Click" class="nv" type="button" data-toggle="tooltip" data-placement="top"
                title="Thêm Sản Phẩm">
                <i>Thêm</i></button>
            <button runat="server" onserverclick="btnExport_Click" class="nv" type="button" data-toggle="tooltip" data-placement="top"
                title="Xuất Danh Sách Sản Phẩm(.xlsm)">
                <i>Xuất</i></button>
            <button runat="server" onserverclick="btnPrint_Click" class="nv" type="button" data-toggle="tooltip" data-placement="top"
                title="In Danh Sách Sản Phẩm">
                <i>In</i></button>
        </div>
        <div>
            <center>
                <asp:GridView ID="gvData" runat="server" Height="100%" Width="100%"
                    AllowPaging="True" PageSize="6"
                    CssClass="custom-gridview" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"
                    DataKeyNames="masanpham" OnRowEditing="gvData_RowEditing" OnRowUpdating="gvData_RowUpdating" OnRowCancelingEdit="gvData_RowCancelingEdit1" OnPageIndexChanging="gvData_PageIndexChanging" OnRowDeleting="gvData_RowDeleting">
                    <Columns>
                        <asp:TemplateField HeaderText="Mã Sản Phẩm">
                            <EditItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("masanpham") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("masanpham") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tên Sản Phẩm">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("tensanpham") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("tensanpham") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hãng">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtThuongHieu" runat="server" Text='<%# Eval("thuonghieu") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("thuonghieu") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Màu Sắc">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtMauSac" runat="server" Text='<%# Eval("mausac") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("mausac") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Bộ Nhớ">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDungLuong" runat="server" Text='<%# Eval("dungluong") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("dungluong") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Số Lượng">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtSoLuong" runat="server" Text='<%# Eval("soluong") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label9" runat="server" Text='<%# Eval("soluong") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Giá Bán">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtGiaBan" runat="server" Text='<%# Eval("giaban") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%# Eval("giaban") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ngày Cập Nhật">
                            <EditItemTemplate>
                                <asp:Label ID="Label11" runat="server" Text='<%# Eval("ngaycapnhat") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label10" runat="server" Text='<%# Eval("ngaycapnhat") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Chức Năng">
                            <EditItemTemplate>
                                <asp:Button ID="Button3" runat="server" CommandName="update" Text="Lưu" Width="50px" />
                                <asp:Button ID="Button4" runat="server" CommandName="cancel" Text="Hủy" Width="50px" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Button ID="Button1" runat="server" CommandName="edit" Text="Sửa" Width="50px" />
                                <asp:Button ID="Button2" runat="server" CommandName="delete" Text="Xóa" Width="50px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        Chưa Có Dữ Liệu
                    </EmptyDataTemplate>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
            </center>
        </div>
        <!------Footer------>
        <div class="container-fluid end">
            <div class="row text-center">
                <asp:Label Font-Size="0.1px" ID="Label8" runat="server" Text="dffds"></asp:Label>
                <div class="col-lg-12">
                    2023 CopyRight | Design by <a href="#">VNUA</a>
                </div>
            </div>
        </div>
    </form>
    <script src="./Assets/js/main.js"></script>
    <script src="https:://unpkg.com/boxicons@latest/dist/boxicons.js"></script>
    <script src="./Assets/vendor/jquery/jquery-3.2.1.min.js"></script>
    <script src="./Assets/vendor/bootstrap/js/popper.js"></script>
    <script src="./Assets/vendor/bootstrap/js/bootstrap.min.js"></script>
    <script src="./Assets/vendor/select2/select2.min.js"></script>
</body>
</html>
