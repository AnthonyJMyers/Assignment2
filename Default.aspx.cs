using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{

    ShowTrackerEntities db = new ShowTrackerEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var artists = from c in db.Artists
                          orderby c.ArtistName
                          select new { c.ArtistName, c.ArtistKey };

            DropDownList1.DataSource = artists.ToList();
            DropDownList1.DataTextField = "ArtistName";
            DropDownList1.DataValueField = "ArtistKey";
            DropDownList1.DataBind();
        }

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int artKey = int.Parse(DropDownList1.SelectedValue.ToString());
        var show = from b in db.ShowDetails
                 

                   where b.ArtistKey==artKey
                   select new
                   {
                       b.Artist.ArtistName,
                       b.Show.ShowDate,
                       b.Show.ShowName
                   };
        GridView1.DataSource = show.ToList();
        GridView1.DataBind();
    }
}
