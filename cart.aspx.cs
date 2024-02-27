using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace E_Burger
{
    public partial class cart1 : System.Web.UI.Page
    {
        CommonItems commonItems = new CommonItems();

        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        //create new sqlconnection and connection to database by using connection string from web.config file          

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(strcon);

            int Order_id;

            if (Session["userid"] == null)
            //if (Session["userid"] == null)
            {
                Response.Redirect("login.aspx");
            }

            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                DataRow dr;
                dt.Columns.Add("id");
                dt.Columns.Add("itemid");
                dt.Columns.Add("img");
                dt.Columns.Add("pname");
                dt.Columns.Add("pprice");
                dt.Columns.Add("qty");
                dt.Columns.Add("total");

                try
                {
                    if (Session["Cart"] == null)
                    {
                        dr = dt.NewRow();
                        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Items WHERE item_id =" + Request.QueryString["itemid"], conn);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        Order_id = 1;

                        //item details assign to gridview
                        dr["id"] = Order_id;
                        dr["img"] = "images/" + ds.Tables[0].Rows[0]["item_image"].ToString();
                        dr["itemid"] = ds.Tables[0].Rows[0]["item_id"].ToString();
                        dr["pname"] = ds.Tables[0].Rows[0]["item_name"].ToString();
                        dr["pprice"] = ds.Tables[0].Rows[0]["item_price"].ToString();
                        dr["qty"] = Request.QueryString["qty"];

                        //total price section
                        int price = Convert.ToInt32(ds.Tables[0].Rows[0]["item_price"].ToString());
                        int quanty = Convert.ToInt32(Request.QueryString["qty"].ToString());
                        int totprce = price * quanty;
                        dr["total"] = totprce.ToString();

                        //adding to data table
                        dt.Rows.Add(dr);

                        //assign to gridview when added data table
                        DGcart.DataSource = dt;
                        DGcart.DataBind();
                        Session["Cart"] = dt;

                        int etotprice = 0;
                        for (int i = 0; i <= DGcart.Rows.Count - 1; i++)
                        {
                            etotprice = etotprice + Convert.ToInt32(dt.Rows[i]["total"].ToString());
                        }

                        DGcart.FooterRow.Cells[6].Text = etotprice.ToString("#,##0.00");

                        lblprice.Text = "LRK" + etotprice.ToString("#,##0.00");
                        lbltotal.Text = "LRK" + (etotprice + 150.00).ToString("#,##0.00");
                    }
                    else if (Request.QueryString["itemid"] != null && Request.QueryString["qty"] != null)
                    {
                        dt = (DataTable)Session["Cart"];
                        dr = dt.NewRow();

                        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Items WHERE item_id =" + Request.QueryString["itemid"], conn);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        Order_id = dt.Rows.Count + 1;

                        //item details assign to gridview
                        dr["id"] = Order_id;
                        dr["itemid"] = ds.Tables[0].Rows[0]["item_id"].ToString();
                        dr["img"] = "images/" + ds.Tables[0].Rows[0]["item_image"].ToString();
                        dr["pname"] = ds.Tables[0].Rows[0]["item_name"].ToString();
                        dr["pprice"] = ds.Tables[0].Rows[0]["item_price"].ToString();
                        dr["qty"] = Request.QueryString["qty"];

                        //total price section
                        int price = Convert.ToInt32(ds.Tables[0].Rows[0]["item_price"].ToString());
                        int quanty = Convert.ToInt32(Request.QueryString["qty"].ToString());
                        int totprce = price * quanty;
                        dr["total"] = totprce.ToString();

                        //adding to data table
                        dt.Rows.Add(dr);

                        //assign to gridview when added data table
                        DGcart.DataSource = dt;
                        DGcart.DataBind();
                        Session["Cart"] = dt;

                        int etotprice = 0;
                        for (int i = 0; i <= DGcart.Rows.Count - 1; i++)
                        {
                            etotprice = etotprice + Convert.ToInt32(dt.Rows[i]["total"].ToString());
                        }

                        DGcart.FooterRow.Cells[6].Text = etotprice.ToString("#,##0.00");

                        lblprice.Text = "LRK" + etotprice.ToString("#,##0.00");
                        lbltotal.Text = "LRK" + (etotprice + 150.00).ToString("#,##0.00");
                    }
                }
                catch
                {
                    if (Request.QueryString["msg"] != null)
                    {
                        lblMsg.CssClass = "m-3";
                        lblMsg.Text = Request.QueryString["msg"];
                    }
                }
            }
        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(strcon);

            DataTable dt;
            dt = (DataTable)Session["Cart"];
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                String date_time = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                double orderQty = double.Parse(dt.Rows[i]["qty"].ToString());
                double orderTotal = double.Parse(dt.Rows[i]["total"].ToString());
                int itemid = int.Parse(dt.Rows[i]["itemid"].ToString());
                string userid = Session["userid"].ToString();

                conn.Open();
                string query = "INSERT INTO Orders (order_datetime, order_status, order_qty, order_total, order_item, order_user) VALUES ('" + date_time + "', 'pending', '" + orderQty + "', '" + orderTotal + "', '" + itemid + "', '" + userid + "')";

                SqlCommand cmd = new SqlCommand(query, conn);

                int db_ressult = cmd.ExecuteNonQuery();

                if (db_ressult > 0)
                {
                    Response.Write("<script>alert('Order Placed Successfully')</script>");
                    //Response.Write("<script>location.href = 'products.aspx'</script>");
                }

                conn.Close();
                Session["Cart"] = null;
            }
            if (Session["userid"] == null)
            {
                Response.Redirect("login.aspx");
            }
            Response.Redirect("checkout.aspx");
        }

        protected void DGcart_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DGcart.EditIndex = e.NewEditIndex;
            DataTable dt = new DataTable();
            dt = (DataTable)Session["Cart"];
            DGcart.DataSource = dt;
            DGcart.DataBind();
        }

        protected void DGcart_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(DGcart.DataKeys[e.RowIndex].Value.ToString());
                int prc = Convert.ToInt32(DGcart.Rows[e.RowIndex].Cells[4].Text);
                string qty = ((TextBox)DGcart.Rows[e.RowIndex].Cells[5].Controls[0]).Text;
                DGcart.Rows[e.RowIndex].Cells[5].Text = qty;
                int int_qty = Convert.ToInt32(DGcart.Rows[e.RowIndex].Cells[5].Text);
                DGcart.Rows[e.RowIndex].Cells[6].Text = (int_qty * prc).ToString();

                DataTable dt = new DataTable();
                dt = (DataTable)Session["Cart"];
                dt.Rows[e.RowIndex]["qty"] = qty;
                dt.Rows[e.RowIndex]["total"] = (int_qty * prc).ToString();
                dt.AcceptChanges();

                Session["Cart"] = dt;
                DGcart.EditIndex = -1;
                DGcart.DataSource = Session["Cart"];
                DGcart.DataBind();

                int etotprice = 0;
                for (int i = 0; i <= DGcart.Rows.Count - 1; i++)
                {
                    etotprice = etotprice + Convert.ToInt32(dt.Rows[i]["total"].ToString());
                }

                DGcart.FooterRow.Cells[6].Text = etotprice.ToString("#,##0.00");

                lblprice.Text = "LRK" + etotprice.ToString("#,##0.00");
                lbltotal.Text = "LRK" + (etotprice + 150.00).ToString("#,##0.00");
            }
            catch
            {
                if (Request.QueryString["msg"] != null)
                {
                    lblMsg.CssClass = "m-3";
                    lblMsg.Text = Request.QueryString["msg"];
                }
            }
        }

        protected void DGcart_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            DGcart.EditIndex = -1;
            DataTable dt = new DataTable();
            dt = (DataTable)Session["Cart"];
            DGcart.DataSource = dt;
            DGcart.DataBind();
        }

        protected void DGcart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["Cart"];

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                int sr;
                int srl;
                string qdata;
                string dtdata;
                sr = Convert.ToInt32(dt.Rows[i]["id"].ToString());
                TableCell cell = DGcart.Rows[e.RowIndex].Cells[0];
                qdata = cell.Text;
                dtdata = sr.ToString();
                srl = Convert.ToInt32(qdata);

                if (sr == srl)
                {
                    dt.Rows[i].Delete();
                    dt.AcceptChanges();
                    break;
                }
            }

            for (int i = 1; i <= dt.Rows.Count; i++)
            {
                dt.Rows[i - 1]["id"] = 1;
                dt.AcceptChanges();
            }

            Session["Cart"] = dt;
            DGcart.DataSource = dt;
            DGcart.DataBind();

            int etotprice = 0;
            for (int i = 0; i <= DGcart.Rows.Count - 1; i++)
            {
                etotprice = etotprice + Convert.ToInt32(dt.Rows[i]["total"].ToString());
            }

            DGcart.FooterRow.Cells[6].Text = etotprice.ToString("#,##0.00");

            lblprice.Text = "LRK" + etotprice.ToString("#,##0.00");
            lbltotal.Text = "LRK" + (etotprice + 150.00).ToString("#,##0.00");
        }

        protected void DGcart_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}