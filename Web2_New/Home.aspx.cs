using iTextSharp.text.pdf;
using iTextSharp.text;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web2_New
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        DBConnection Conn = new DBConnection();
        String sreach = "";
        String AlertUpdate = "swal('Thay Đổi Thông Tin Thành Công');";
        String AlertCancel = "swal('Bạn Đã Hủy Bỏ Việc Thay Đổi Thông Tin');";
        String AlertDelete = "swal('Xóa Sản Phẩm Thành Công');";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDataToGridView();
            }

        }

        public void btnSearch_Click(object sender, EventArgs e)
        {
            Label8.Text = "";
            sreach = txtSearch.Value;
            if (sreach.Trim() != "")
            {
                LoadDataToGridViewSreach();
            }
            else
            {
                LoadDataToGridView();
            }

        }

        public void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("Insert.aspx");
        }

        public void btnExport_Click(object sender, EventArgs e)
        {
            Conn.GetConnection();

            // Tạo một DataTable và nạp dữ liệu từ cơ sở dữ liệu
            DataTable dt = new DataTable();
            Conn.GetConnection();
            String sql = "SELECT * FROM tbl_Products";
            SqlDataAdapter data = new SqlDataAdapter(sql, Conn.GetConnection());
            data.Fill(dt);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Tạo một tệp tin Excel tạm thời
            string tempFileName = Path.GetTempFileName();
            FileInfo newFile = new FileInfo(tempFileName);

            using (ExcelPackage package = new ExcelPackage(newFile))
            {
                // Tạo một sheet trong tệp tin Excel
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // Đổ dữ liệu từ DataTable vào sheet
                worksheet.Cells["A1"].LoadFromDataTable(dt, true);

                // Lưu tệp tin Excel tạm thời
                package.Save();
            }

            // Gửi tệp tin Excel cho người dùng để tải về
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=Danh_Sach_San_Pham.xlsx");
            Response.TransmitFile(tempFileName);
            Response.End();

            // Xóa tệp tin Excel tạm thời sau khi đã gửi đi
            File.Delete(tempFileName);

            Conn.CloseConnection();
        }

        public void btnPrint_Click(object sender, EventArgs e)
        {
            Conn.GetConnection();

            //Tạo datatable chứa dữ liệu
            DataTable dt = new DataTable();
            
            String sql = "SELECT * FROM tbl_Products";
            SqlDataAdapter data = new SqlDataAdapter(sql, Conn.GetConnection());
            data.Fill(dt);

            // Tạo một Document và PdfWriter
            Document document = new Document();
            MemoryStream ms = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(document, ms);

            // Mở Document để bắt đầu viết PDF
            document.Open();

            // Thêm nội dung từ DataTable vào PDF
            PdfPTable pdfTable = new PdfPTable(dt.Columns.Count);
            pdfTable.WidthPercentage = 100;

            // Thêm tiêu đề cột từ DataTable
            foreach (DataColumn column in dt.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName));
                pdfTable.AddCell(cell);
            }

            // Thêm dữ liệu từ DataTable
            foreach (DataRow row in dt.Rows)
            {
                foreach (object item in row.ItemArray)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(item.ToString()));
                    pdfTable.AddCell(cell);
                }
            }
            document.Add(pdfTable);

            // Đóng Document
            document.Close();

            // Xuất PDF ra response
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Danh_Sach_San_Pham.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
            Response.End();

            Conn.CloseConnection();
        }

        public void btnDataAll_Click(object sender, EventArgs e)
        {
            Label8.Text = "";
            LoadDataToGridView();
            gvData.PageIndex = 0;
        }

        public void btnDataApple_Click(object sender, EventArgs e)
        {
            Label8.Text = "apple";
            LoadDataToGridThuongHieu(Label8.Text);
        }

        public void btnDataSamsung_Click(object sender, EventArgs e)
        {
            Label8.Text = "samsung";
            LoadDataToGridThuongHieu(Label8.Text);
        }

        public void btnDataOppo_Click(object sender, EventArgs e)
        {
            Label8.Text = "oppo";
            LoadDataToGridThuongHieu(Label8.Text);
        }

        public void btnDataXiaomi_Click(object sender, EventArgs e)
        {
            Label8.Text = "xiaomi";
            LoadDataToGridThuongHieu(Label8.Text);
        }

        public void btnDataHauwei_Click(object sender, EventArgs e)
        {
            Label8.Text = "hauwei";
            LoadDataToGridThuongHieu(Label8.Text);
        }

        public void LoadDataToGridView()
        {
            DataTable db = new DataTable();

            Conn.GetConnection();
            String sql = "SELECT * FROM tbl_Products";
            SqlDataAdapter data = new SqlDataAdapter(sql, Conn.GetConnection());
            data.Fill(db);
            gvData.DataSource = db;
            gvData.DataBind();
            Conn.CloseConnection();
        }

        public void LoadDataToGridViewSreach()
        {
            String sreach = txtSearch.Value;
            DataTable db = new DataTable();

            Conn.GetConnection();
            String sql = "SELECT * FROM tbl_Products WHERE tensanpham LIKE '%" + sreach + "%'";
            SqlDataAdapter data = new SqlDataAdapter(sql, Conn.GetConnection());
            data.Fill(db);
            gvData.DataSource = db;
            gvData.DataBind();
            Conn.CloseConnection();
        }

        public void LoadDataToGridThuongHieu(String thuonghieu)
        {
            DataTable db = new DataTable();

            Conn.GetConnection();

            String sql = "SELECT * FROM tbl_Products WHERE thuonghieu LIKE '%" + thuonghieu + "%'";
            SqlDataAdapter data = new SqlDataAdapter(sql, Conn.GetConnection());
            data.Fill(db);
            gvData.DataSource = db;
            gvData.DataBind();

            Conn.CloseConnection();
        }

        public void gvData_RowEditing(object sender, GridViewEditEventArgs e)
        {
            String sreach = txtSearch.Value;

            if (String.Compare(sreach, "") != 0)
            {
                gvData.EditIndex = e.NewEditIndex;
                LoadDataToGridViewSreach();
            }
            else if (String.Compare(Label8.Text, "apple") == 0)
            {
                gvData.EditIndex = e.NewEditIndex;
                LoadDataToGridThuongHieu(Label8.Text);
            }
            else if (String.Compare(Label8.Text, "samsung") == 0)
            {
                gvData.EditIndex = e.NewEditIndex;
                LoadDataToGridThuongHieu(Label8.Text);
            }
            else if (String.Compare(Label8.Text, "oppo") == 0)
            {
                gvData.EditIndex = e.NewEditIndex;
                LoadDataToGridThuongHieu(Label8.Text);
            }
            else if (String.Compare(Label8.Text, "xiaomi") == 0)
            {
                gvData.EditIndex = e.NewEditIndex;
                LoadDataToGridThuongHieu(Label8.Text);
            }
            else if (String.Compare(Label8.Text, "hauwei") == 0)
            {

                gvData.EditIndex = e.NewEditIndex;
                LoadDataToGridThuongHieu(Label8.Text);
            }
            else
            {
                gvData.EditIndex = e.NewEditIndex;
                LoadDataToGridView();
            }
        }

        public void gvData_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Conn.GetConnection();
            string update = "UPDATE tbl_Products SET tensanpham=@tensanpham," +
                            " thuonghieu=@thuonghieu, mausac=@mausac, dungluong=@dungluong," +
                            "soluong=@soluong, giaban=@giaban, ngaycapnhat=@ngaycapnhat WHERE masanpham=@masanpham";

            SqlCommand cmd = new SqlCommand(update, Conn.GetConnection());
            cmd.Parameters.AddWithValue("@tensanpham", (gvData.Rows[e.RowIndex].FindControl("txtName") as TextBox).Text.Trim());
            cmd.Parameters.AddWithValue("@thuonghieu", (gvData.Rows[e.RowIndex].FindControl("txtThuongHieu") as TextBox).Text.Trim());
            cmd.Parameters.AddWithValue("@mausac", (gvData.Rows[e.RowIndex].FindControl("txtMauSac") as TextBox).Text.Trim());
            cmd.Parameters.AddWithValue("@dungluong", (gvData.Rows[e.RowIndex].FindControl("txtDungLuong") as TextBox).Text.Trim());
            cmd.Parameters.AddWithValue("@soluong", (gvData.Rows[e.RowIndex].FindControl("txtSoLuong") as TextBox).Text.Trim());
            cmd.Parameters.AddWithValue("@giaban", (gvData.Rows[e.RowIndex].FindControl("txtGiaBan") as TextBox).Text.Trim());
            cmd.Parameters.AddWithValue("@ngaycapnhat", Date.GetCurrentDateTimeString());
            cmd.Parameters.AddWithValue("@masanpham", gvData.DataKeys[e.RowIndex].Value.ToString());

            cmd.ExecuteNonQuery();

            Conn.CloseConnection();

            String sreach = txtSearch.Value;

            if (String.Compare(sreach, "") != 0)
            {
                gvData.EditIndex = -1;
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", AlertUpdate, true);
                LoadDataToGridViewSreach();
            }
            else if (String.Compare(Label8.Text, "apple") == 0)
            {
                gvData.EditIndex = -1;
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", AlertUpdate, true);
                LoadDataToGridThuongHieu(Label8.Text);
            }
            else if (String.Compare(Label8.Text, "samsung") == 0)
            {
                gvData.EditIndex = -1;
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", AlertUpdate, true);
                LoadDataToGridThuongHieu(Label8.Text);
            }
            else if (String.Compare(Label8.Text, "oppo") == 0)
            {
                gvData.EditIndex = -1;
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", AlertUpdate, true);
                LoadDataToGridThuongHieu(Label8.Text);
            }
            else if (String.Compare(Label8.Text, "xiaomi") == 0)
            {
                gvData.EditIndex = -1;
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", AlertUpdate, true);
                LoadDataToGridThuongHieu(Label8.Text);
            }
            else if (String.Compare(Label8.Text, "hauwei") == 0)
            {

                gvData.EditIndex = -1;
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", AlertUpdate, true);
                LoadDataToGridThuongHieu(Label8.Text);
            }
            else
            {
                gvData.EditIndex = -1;
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", AlertUpdate, true);
                LoadDataToGridView();
            }
        }

        public void gvData_RowCancelingEdit1(object sender, GridViewCancelEditEventArgs e)
        {
            String sreach = txtSearch.Value;

            if (String.Compare(sreach, "") != 0)
            {
                gvData.EditIndex = -1;
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", AlertCancel, true);
                LoadDataToGridViewSreach();
            }
            else if (String.Compare(Label8.Text, "apple") == 0)
            {
                gvData.EditIndex = -1;
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", AlertCancel, true);
                LoadDataToGridThuongHieu(Label8.Text);
            }
            else if (String.Compare(Label8.Text, "samsung") == 0)
            {
                gvData.EditIndex = -1;
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", AlertCancel, true);
                LoadDataToGridThuongHieu(Label8.Text);
            }
            else if (String.Compare(Label8.Text, "oppo") == 0)
            {
                gvData.EditIndex = -1;
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", AlertCancel, true);
                LoadDataToGridThuongHieu(Label8.Text);
            }
            else if (String.Compare(Label8.Text, "xiaomi") == 0)
            {
                gvData.EditIndex = -1;
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", AlertCancel, true);
                LoadDataToGridThuongHieu(Label8.Text);
            }
            else if (String.Compare(Label8.Text, "hauwei") == 0)
            {

                gvData.EditIndex = -1;
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", AlertCancel, true);
                LoadDataToGridThuongHieu(Label8.Text);
            }
            else
            {
                gvData.EditIndex = -1;
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", AlertCancel, true);
                LoadDataToGridView();
            }
        }

        protected void gvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            String sreach = txtSearch.Value;

            if (String.Compare(sreach, "") != 0)
            {
                gvData.PageIndex = e.NewPageIndex;
                LoadDataToGridViewSreach();
            }
            else if (String.Compare(Label8.Text, "apple") == 0)
            {
                gvData.PageIndex = e.NewPageIndex;
                LoadDataToGridThuongHieu(Label8.Text);
            }
            else if (String.Compare(Label8.Text, "samsung") == 0)
            {
                gvData.PageIndex = e.NewPageIndex;
                LoadDataToGridThuongHieu(Label8.Text);
            }
            else if (String.Compare(Label8.Text, "oppo") == 0)
            {
                gvData.PageIndex = e.NewPageIndex;
                LoadDataToGridThuongHieu(Label8.Text);
            }
            else if (String.Compare(Label8.Text, "xiaomi") == 0)
            {
                gvData.PageIndex = e.NewPageIndex;
                LoadDataToGridThuongHieu(Label8.Text);
            }
            else if (String.Compare(Label8.Text, "hauwei") == 0)
            {

                gvData.PageIndex = e.NewPageIndex;
                LoadDataToGridThuongHieu(Label8.Text);
            }
            else
            {
                gvData.PageIndex = e.NewPageIndex;
                LoadDataToGridView();
            }
        }

        protected void gvData_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Conn.GetConnection();
            String delete = "DELETE FROM tbl_Products WHERE masanpham=@masanpham";
            SqlCommand cmd = new SqlCommand(delete, Conn.GetConnection());
            cmd.Parameters.AddWithValue("@masanpham", gvData.DataKeys[e.RowIndex].Value.ToString());
            cmd.ExecuteNonQuery();
            Conn.CloseConnection();

            String sreach = txtSearch.Value;

            if (String.Compare(sreach, "") != 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", AlertDelete, true);
                LoadDataToGridViewSreach();
            }
            else if (String.Compare(Label8.Text, "apple") == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", AlertDelete, true);
                LoadDataToGridThuongHieu(Label8.Text);
            }
            else if (String.Compare(Label8.Text, "samsung") == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", AlertDelete, true);
                LoadDataToGridThuongHieu(Label8.Text);
            }
            else if (String.Compare(Label8.Text, "oppo") == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", AlertDelete, true);
                LoadDataToGridThuongHieu(Label8.Text);
            }
            else if (String.Compare(Label8.Text, "xiaomi") == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", AlertDelete, true);
                LoadDataToGridThuongHieu(Label8.Text);
            }
            else if (String.Compare(Label8.Text, "hauwei") == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", AlertDelete, true);
                LoadDataToGridThuongHieu(Label8.Text);
            }
            else
            { 
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", AlertDelete, true);
                LoadDataToGridView();
            }
        }
    }
}