using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web2_New
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        DBConnection Conn = new DBConnection();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String username = txtUsername.Value;
            String password = txtPassword.Value;

            if (username.Trim() == "" || password.Trim() == "")
            {
                string script = "swal('Tài Khoản/Mật Khẩu Không Được Để Trống');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "PopupScript", script, true);
            }
            else
            {
                Conn.GetConnection();
                String sql = "SELECT * FROM tbl_Account WHERE username='" + username + "' AND password='" + password + "'";
                SqlCommand sqlCommand = new SqlCommand(sql, Conn.GetConnection());
                using (SqlDataReader data = sqlCommand.ExecuteReader())
                {
                    if (data.Read())
                    {
                        data.Close();
                        Response.Redirect("./Home.aspx");
                    }
                    else
                    {
                        data.Close();
                        string script = "swal('Tài Khoản/Mật Khẩu Không Đúng');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "PopupScript", script, true);
                    }
                }
            }
        }
    }
}