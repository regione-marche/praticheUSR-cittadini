using RicercaPratiche.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RicercaPratiche.DesktopModules.RegioneMarche2016.RicercaPratiche.Dettagli
{
	public partial class AutorizzazionePagamentoSAL : System.Web.UI.Page
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

				if (row.DataDecretoSal0.HasValue)
					this.ltl_SAl0.Text = String.Format("Dec. N° {0} del {1}", row.NumeroDecretoSal0, row.DataDecretoSal0.Value.ToShortDateString());
				else
					this.ltl_SAl0.Text = "---";
				/* ------------------------ */

				if (row.DataDecretoSal20.HasValue)
					this.ltl_Sal20.Text = String.Format("Dec. N° {0} del {1}", row.NumeroDecretoSal20, row.DataDecretoSal20.Value.ToShortDateString());
				else
					this.ltl_Sal20.Text = "---";
				/* ------------------------ */

				if (row.DataDecretoSal40.HasValue)
					this.ltl_Sal40.Text = String.Format("Dec. N° {0} del {1}", row.NumeroDecretoSal40, row.DataDecretoSal40.Value.ToShortDateString());
				else
					this.ltl_Sal40.Text = "---";
				/* ------------------------ */

				if (row.DataDecretoSal50.HasValue)
					this.ltl_Sal50.Text = String.Format("Dec. N° {0} del {1}", row.NumeroDecretoSal50, row.DataDecretoSal50.Value.ToShortDateString());
				else
					this.ltl_Sal50.Text = "---";
				/* ------------------------ */

				if (row.DataDecretoSal70.HasValue)
					this.ltl_Sal70.Text = String.Format("Dec. N° {0} del {1}", row.NumeroDecretoSal70, row.DataDecretoSal70.Value.ToShortDateString());
				else
					this.ltl_Sal70.Text = "---";
				/* ------------------------ */

				if (row.DataDecretoSalFL.HasValue)
					this.ltl_PresSalFineLavori.Text = String.Format("Dec. N° {0} del {1}", row.NumeroDecretoSalFL, row.DataDecretoSalFL.Value.ToShortDateString());
				else
					this.ltl_PresSalFineLavori.Text = "---";
			}
		}
	}
}