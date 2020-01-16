using RicercaPratiche.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RicercaPratiche.DesktopModules.RegioneMarche2016.RicercaPratiche
{
	public partial class Default : System.Web.UI.Page
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!this.IsPostBack)
				this.LoadData();
		}
		// =================================================
		/// <summary>
		/// 
		/// </summary>
		private void LoadData()
		{
			
			using (wsSisma16DBEntities _e = new wsSisma16DBEntities())
			{
				int id = Int32.Parse(this.Request.QueryString["ID"] ?? "1");

				var row = _e.tmpVB01StatoFasiPratica.FirstOrDefault(f => f.IdRichiesta == id);
				if (row == null)
					return;

				this.ltl_CodiceFascicolo.Text = "Codice fascicolo : " + row.CodiceFascicolo;
				this.ltl_Autorizzazione_Pagamento.CssClass = setStatus(row.AutorizzazionePagamento, this.ltl_Autorizzazione_Pagamento, "Autorizzazione pagamento");
				this.ltl_Concessione_contributo_USR.CssClass = setStatus(row.ConcessioneContributoUSR, this.ltl_Concessione_contributo_USR, "Concessione contributo USR");
				this.ltl_Esecuzione_Lavori.CssClass = setStatus(row.EsecuzioneLavori, this.ltl_Esecuzione_Lavori, "Esecuzione lavori");
				this.ltl_Integrazione_ProfessionistaSAL.CssClass = setStatus(row.RichiestaIntegrazioniSAL, this.ltl_Integrazione_ProfessionistaSAL, "Integrazione professionista SAL");
				this.ltl_Istruttoria_SAL_USR.CssClass = setStatus(row.IstruttoriaSAL, this.ltl_Istruttoria_SAL_USR, "Istruttoria SAL USR");
				this.ltl_Pratica_Conclusa.CssClass = row.PraticaConclusa == 1 ? "green" : "lightGray";

			}
		}
		// ===================================================
		/// <summary>
		/// 
		/// </summary>
		/// <param name="val"></param>
		/// <returns></returns>
		private string setStatus(String val, Label ltl, string Text)
		{
			string res = "lightGray";

			if (val == "C")
			{
				ltl.Text = "<i class='glyphicon glyphicon-ok'></i>&nbsp;" + Text + "&nbsp;<i class='glyphicon glyphicon-zoom-in'></i>";
				res = "green";
			}

			else if (val == "red")
			{
				ltl.Text = "<i class='glyphicon glyphicon-remove'></i>&nbsp;" + Text + "&nbsp;<i class='glyphicon glyphicon-zoom-in'></i>";
				res = "red";
			}

			else if (val == "A")
			{
				ltl.Text = "<i class='glyphicon glyphicon-arrow-right'></i>&nbsp;" + Text + "&nbsp;<i class='glyphicon glyphicon-zoom-in'></i>";
				res = "yellow";
			}

			/* */
			return res;

		}
	}
}