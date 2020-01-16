using RicercaPratiche.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RicercaPratiche.DesktopModules.RegioneMarche2016.RicercaPratiche.Dettagli
{
	public partial class ConferenzaRegionale : System.Web.UI.Page
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

				/* ------------------------ */

				if (row.DataRichiestaConferenzaReg.HasValue)
					this.ltl_DataRichiestaConfRegionale.Text = row.DataRichiestaConferenzaReg.Value.ToShortDateString();
				else
					this.ltl_DataRichiestaConfRegionale.Text = "---";

				/* ------------------------ */

				if (row.DataRichiestaConferenzaReg.HasValue)
					this.ltl_DataConvocazioneConfRegionale.Text = row.DataRichiestaConferenzaReg.Value.ToShortDateString();
				else
					this.ltl_DataConvocazioneConfRegionale.Text = "---";

				/* ------------------------ */

				if (row.DataEsitoConferenzaReg.HasValue)
					this.ltl_DataParereConfRegionale.Text = row.DataEsitoConferenzaReg.Value.ToShortDateString();
				else
					this.ltl_DataParereConfRegionale.Text = "---";
			}
		}
	}
}