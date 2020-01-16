using RicercaPratiche.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RicercaPratiche.DesktopModules.RegioneMarche2016.RicercaPratiche.Dettagli
{
	public partial class IstruttoriaComune : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			///
			using (wsSisma16DBEntities _e = new wsSisma16DBEntities())
			{
				System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("it-IT");

				/* */
				int aid = Int32.Parse(this.Request.QueryString["aid"] ?? "1");
				var row = _e.tmpvB02DettaglioPratica.FirstOrDefault(w => w.IdRichiesta == aid);
				if (row == null)
					return;

				if (row.DataInvioChecklistComune.HasValue)
					this.ltl_Data.Text = row.DataTrasmissioneAComune.Value.ToShortDateString();
				else
					this.ltl_Data.Text = "---";


				if (row.DataSospensionePerimetrazioni.HasValue)
					this.Literal1.Text = row.DataSospensionePerimetrazioni.Value.ToShortDateString();
				else
					this.Literal1.Text = "---";


				if (row.DataRilascioPdC.HasValue)
					this.Literal2.Text = row.DataRilascioPdC.Value.ToShortDateString();
				else
					this.Literal2.Text = "---";


				if (row.DataScadenzaRispostaComune.HasValue)
					this.Literal3.Text = row.DataScadenzaRispostaComune.Value.ToShortDateString();
				else
					this.Literal3.Text = "---";

			}
		}
	}
}