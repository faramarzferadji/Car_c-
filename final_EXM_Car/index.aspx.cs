using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace final_EXM_Car
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            panfinal.Visible = false;
            if (!Page.IsPostBack)
            {
                LabelPhone.Visible = txtPhone.Visible = false;
                cboCar.Items.Add(new ListItem("Civic", "25000"));
                cboCar.Items.Add(new ListItem("CRV", "30000"));
                cboCar.Items.Add(new ListItem("Odyse", "35000"));
                cboCar.Items.Add(new ListItem("Sport", "40000"));
                cboCar.Items.Add(new ListItem("Accord", "45000"));
                cboCar.SelectedIndex = 0;

                Listcolor.Items.Add(new ListItem("White","0"));
                Listcolor.Items.Add(new ListItem("Dark","300"));
                Listcolor.Items.Add(new ListItem("Pearl", "900"));
                Listcolor.SelectedIndex = 0;

                ChklisAcces.Items.Add(new ListItem("AiroKite", "1300"));
                ChklisAcces.Items.Add(new ListItem("Film", "600"));
                ChklisAcces.Items.Add(new ListItem("Cold Weather", "900"));
                ChklisAcces.Items.Add(new ListItem("Sport tire", "1000"));
                ChklisAcces.Items.Add(new ListItem("Spurt Rime", "1500"));
               
                ChklisAcces.SelectedIndex = 0;

                radlistWarant.Items.Add(new ListItem("3", "0"));
                radlistWarant.Items.Add(new ListItem("5", "1000"));
                radlistWarant.Items.Add(new ListItem("7", "1500"));
                radlistWarant.SelectedIndex = 0;

            }
            if(cboCar.SelectedIndex > 0)
            {
                CalculePrice();
            }

        }
        private void CalculePrice()
        {
            decimal carPrice = 0, Interior = 0, Accessoires = 0, Warranty = 0, TotWitoutTx = 0, Total = 0, year=0;
            String modelc = "", address = "", zipcod = "", coint = "", acces = "", tel = "";
            carPrice = Convert.ToDecimal(cboCar.SelectedItem.Value);

            litPrice.Text = "<br><b> Car Price = $ <b>" + carPrice + "</br>";
            Interior= Convert.ToDecimal(Listcolor.SelectedItem.Value);
            litPrice.Text += "<br><b> Interior Color = $ <b>" + Interior + "</br>";
            if (ChDealer.Checked)
            {
                txtPhone.Visible = true;
                LabelPhone.Visible = true;
            }

            foreach(ListItem item in ChklisAcces.Items)
            {
                Accessoires += (item.Selected) ? Convert.ToDecimal(item.Value) : 0;
            }
            litPrice.Text += "<br><b> accessoir = $ <b>" + Accessoires + "</br>";
            foreach (ListItem item in radlistWarant.Items)
            {
                Warranty += (item.Selected) ? Convert.ToDecimal(item.Value) : 0;
            }
            litPrice.Text += "<br><b> warranty = $ <b>" + Warranty + "</br>";



            TotWitoutTx = carPrice + Interior + Accessoires + Warranty;
            litPrice.Text += "<br><b> Total Without Taxes = $ <b>" + TotWitoutTx + "</br>";
            Total += Math.Round(TotWitoutTx * Convert.ToDecimal(1.15), 2);
            litPrice.Text += "<br><b> Total With Taxes(15%) = $ <b>" + Total + "</br>";
        }

        protected void txtCity_TextChanged(object sender, EventArgs e)
        {

        }

        protected void cboCar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Listcolor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btncon_Click(object sender, EventArgs e)
        {
            if (btncon.Enabled)
            {
                panfinal.Visible = true;
            }
            decimal carPrice = 0, Interior = 0, Accessoires = 0, Warranty = 0, TotWitoutTx = 0, Total = 0, year = 0;
            String modelc = "",  zipcod = "", coint = "", acces = "", tel = "", city="";
            modelc = cboCar.SelectedItem.Text;
            zipcod = txtZip.Text;
            city = txtCity.Text;
            coint = Listcolor.SelectedItem.Text;
            foreach (ListItem item in ChklisAcces.Items)
            {
                if (item.Selected)
                {
                    acces += ChklisAcces.SelectedIndex.ToString(item.Text);
                }
                
            }

            foreach(ListItem item in radlistWarant.Items)
            {

                year = Convert.ToDecimal(radlistWarant.SelectedItem.Text);
            }
            tel = txtPhone.Text;
            litInfo.Text = "Congratulation in obtain your new Honda" + modelc + "in" + city +
                "," + zipcod + "." + "your car cames with" + coint + "color and with" + acces + "Accessories." +
                "you choosed " + year + "years of warranty and our dealer will contact you by the phone number:" + tel;
                
            





        }

        protected void txtZip_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ChklisAcces_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ChDealer_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void radlistWarant_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}