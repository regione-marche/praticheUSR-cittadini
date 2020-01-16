using RicercaPratiche.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RicercaPratiche.DesktopModules.RegioneMarche2016.RicercaPratiche.Dettagli
{
	public partial class IntegrazioneProfessionistaUSR : System.Web.UI.Page
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

				/* */
				if (row.DataPrimaRichiestaIntUSR.HasValue)
					this.ltl_data1richiesta.Text = row.DataPrimaRichiestaIntUSR.Value.ToShortDateString();
				else
					this.ltl_data1richiesta.Text = "---";

				/* */
				if (row.DataUltimaRichiestaIntUSR.HasValue)
					this.ltl_DataUrichiesta.Text = row.DataUltimaRichiestaIntUSR.Value.ToShortDateString();
				else
					this.ltl_DataUrichiesta.Text = "---";

				/* */
				if (row.DataRicezioneUltimaIntUSR.HasValue)
					this.ltl_DataIntegrazioneProfessionista.Text = row.DataRicezioneUltimaIntUSR.Value.ToShortDateString();
				else
					this.ltl_DataIntegrazioneProfessionista.Text = "---";
			}

		}
	}
}