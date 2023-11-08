#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using ModelEF6;
using System.Linq;
using System.Linq.Dynamic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using System.Globalization;

#endregion

namespace SPF.UserControls.UI
{
    public partial class ucConfMenu : ucBaseForm
    {
        #region Variables
        //private testMenuDBEntities db;
        #endregion Variables

        public ucConfMenu(string Titulo = "Sin Título", BerkeDBEntities dbContext = null)
        {
            InitializeComponent();
            this.Titulo = Titulo;
            this.DBContext = dbContext;
            this.DBContext = dbContext;
            this.DBContext.mn_menu.Take(50).OrderByDescending(b => b.mn_idmenu).Load();
            this.BindingSourceBase = this.DBContext.mn_menu.Local.ToBindingList();
        }

       protected override void FilterEntity(string where, object [] filterParams)
        {
            try
            {
                var query = this.DBContext.mn_menu.Where(where, filterParams);
                this.BindingSourceBase = query.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al filtrar los datos: " + Environment.NewLine + ex.Message, "Información de Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void ucConfMenu_Load(object sender, EventArgs e)
        {
            #region Especificar campos para filtro
            this.SetFilter("mn_idmenu", "ID Menú", false);
            this.SetFilter("mn_clave", "Clave Menú");
            this.SetFilter("mn_titulo", "Título Menú");
            this.SetFilter("mn_fecha", "Fecha Menú");
            this.SetFilter("mn_fechahora", "FechaHora Menú");
            this.TituloBuscador = "Buscar Menú";
            #endregion Especificar campos para filtro
        }

       

    }
}