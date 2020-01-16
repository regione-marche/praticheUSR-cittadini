using RicercaPratiche.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RicercaPratiche.DesktopModules.RegioneMarche2016.RicercaPratiche.Dettagli
{
	public partial class IntegrazioneProfessionistaSAL : System.Web.UI.Page
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

				if (row.DataUltimaRichiestaIntSAL.HasValue)
					this.ltl_DataIntegrazioneSal.Text = row.DataUltimaRichiestaIntSAL.Value.ToShortDateString();
				else
					this.ltl_DataIntegrazioneSal.Text = "---";

				/* ------------------------ */

				if (row.DataUltimaIntSal0.HasValue)
					this.ltl_SAl0.Text = row.DataUltimaIntSal0.Value.ToShortDateString();
				else
					this.ltl_SAl0.Text = "---";
				/* ------------------------ */

				if (row.DataUltimaIntSal20.HasValue)
					this.ltl_Sal20.Text = row.DataUltimaIntSal20.Value.ToShortDateString();
				else
					this.ltl_Sal20.Text = "---";
				/* ------------------------ */

				if (row.DataUltimaIntSal40.HasValue)
					this.ltl_Sal40.Text = row.DataUltimaIntSal40.Value.ToShortDateString();
				else
					this.ltl_Sal40.Text = "---";
				/* ------------------------ */

				if (row.DataUltimaIntSal50.HasValue)
					this.ltl_Sal50.Text = row.DataUltimaIntSal50.Value.ToShortDateString();
				else
					this.ltl_Sal50.Text = "---";
				/* ------------------------ */

				if (row.DataUltimaIntSal70.HasValue)
					this.ltl_Sal70.Text = row.DataUltimaIntSal70.Value.ToShortDateString();
				else
					this.ltl_Sal70.Text = "---";
				/* ------------------------ */

				if (row.DataUltimaIntSalFL.HasValue)
					this.ltl_DataIntegrazioneFineLavori.Text = row.DataUltimaIntSalFL.Value.ToShortDateString();
				else
					this.ltl_DataIntegrazioneFineLavori.Text = "---";
			}
		}
	}
}