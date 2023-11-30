using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm
{
    public partial class SumForm : System.Web.UI.Page
    {
        private Simplex simplex;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.simplex = new Simplex();
        }

        protected void Sum_Click(object sender, EventArgs e)
        {
            int x = Int32.Parse(number_one.Text.ToString());
            int y = Int32.Parse(number_two.Text.ToString());
            result.Text = simplex.Add(x, y).ToString();
        }
        //protected void Concat_Click(object sender, EventArgs e)
        //{
        //    string s = str.Text;
        //    double d = Double.Parse(number_two.Text.ToString());
        //    result.Text = simplex.Concat(s, d).ToString();
        //}
    }
}