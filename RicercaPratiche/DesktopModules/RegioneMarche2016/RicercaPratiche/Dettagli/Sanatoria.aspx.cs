using RicercaPratiche.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RicercaPratiche.DesktopModules.RegioneMarche2016.RicercaPratiche.Dettagli
{
	public partial class Sanatoria : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			using (wsSisma16DBEntities _e = new wsSisma16DBEntities())
			{
				System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("it-IT");

				/* */
				int aid = Int32.Parse(this.Request.QueryString["aid"] ?? "1");
				var row = _e.tmpvB02DettaglioPratica.FirstOrDefault(w => w.IdRichiesta == aid);
				if (row == null)
					return;

				if (row.DataSanatoria.HasValue)
					this.ltl_DataSospensione.Text = row.DataSanatoria.Value.ToShortDateString();
				else
					this.ltl_DataSospensione.Text = "---";

				if (row.SanatoriaCompletata == 1)
					this.ltl_SanatoriaCompletata.Text = "SI";
				else
					this.ltl_SanatoriaCompletata.Text = "NO";

				//@NOFIELD
				//if (row.DataRicezioneUltimaIntComune.HasValue)
				//    this.ltl_DataIntegrazioneProfessionista.Text = row.pro.Value.ToShortDateString();
				//else
				//    this.ltl_DataIntegrazioneProfessionista.Text = "---";

			}
		}
	}
}