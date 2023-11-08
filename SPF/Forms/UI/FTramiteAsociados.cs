#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using ModelEF6;
using SPF.Types;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;
using System.Linq.Dynamic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Collections.ObjectModel;

using SPF.Forms.Base;

#endregion

namespace SPF.Forms.UI
{
    public partial class FTramiteAsociados : Form
    {
        #region Variables
        BerkeDBEntities DBContext;
        //IBindingList bindingList;
        BindingList<TramiteType> bList1;
        BindingList<TramiteType> bList2;
        int TarifaID = -1;
        #endregion Variables

        #region Constantes
        public const string BROWSE = "BROWSE";
        public const string INSERT = "INSERT";
        public const string EDIT = "EDIT";
        #endregion Constantes

        public FTramiteAsociados()
        {
            InitializeComponent();
        }

        public FTramiteAsociados(BerkeDBEntities context, string estadoEdicion, int tarifaID)
        {
            InitializeComponent();
            this.DBContext = context;
            this.TarifaID = tarifaID;
            this.Text = "Trámites Asociados a la Tarifa";

            //this.undoChanges();

            //this.DBContext.Tramite.Load();
            //this.DBContext.trr_tramitetarifa.Load();
            
            this.cargarListBoxes();

            //if (estadoEdicion != BROWSE)
            //{
            //    this.btnAgregar.Enabled = true;
            //    this.btnQuitar.Enabled = true;
            //    this.listBox1.Enabled = true;
            //    this.listBox2.Enabled = true;
            //}
            //else
            //{
            //    this.btnAgregar.Enabled = false;
            //    this.btnQuitar.Enabled = false;
            //    this.listBox1.Enabled = false;
            //    this.listBox2.Enabled = false;
            //}
        }

        private void cargarListBoxes()
        {
            #region Listbox2
            var qry = (from trr in this.DBContext.trr_tramitetarifa//.Local
                       join trm in this.DBContext.Tramite//.Local
                         on trr.ttr_tramiteid equals trm.ID
                       select new TramiteType
                       {
                           TramiteID = trr.ttr_tramiteid,
                           DescripcionTramite = trm.Descrip,
                           TarifaID = trr.ttr_tarifaid,
                           TrrID = trr.ttr_id
                       }).Where(a => a.TarifaID == this.TarifaID);


            bList2 = new BindingList<TramiteType>(qry.ToList());
            this.listBox2.DataSource = bList2;
            this.listBox2.DisplayMember = "DescripcionTramite";
            this.listBox2.ValueMember = "TramiteID";
            #endregion Listbox2

            #region Listbox1
            var qry1 = from trm in this.DBContext.Tramite//.Local
                       where !(from trr in this.DBContext.trr_tramitetarifa//.Local
                               where trr.ttr_tarifaid == this.TarifaID
                               select trr.ttr_tramiteid).Contains(trm.ID)
                       select new TramiteType
                       {
                           TramiteID = trm.ID,
                           DescripcionTramite = trm.Descrip
                       };


            bList1 = new BindingList<TramiteType>(qry1.ToList());
            this.listBox1.DataSource = bList1;
            this.listBox1.DisplayMember = "DescripcionTramite";
            this.listBox1.ValueMember = "TramiteID";
            #endregion Listbox1
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            trr_tramitetarifa trr = new trr_tramitetarifa { ttr_tarifaid = this.TarifaID, ttr_tramiteid = Convert.ToInt32(this.listBox1.SelectedValue) };
            this.DBContext.trr_tramitetarifa.Add(trr);
            this.DBContext.SaveChanges();
            this.cargarListBoxes();
            
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (((TramiteType)this.listBox2.SelectedItem).TrrID.HasValue)
            {
                int ttrID = ((TramiteType)this.listBox2.SelectedItem).TrrID.Value;
                trr_tramitetarifa trr = this.DBContext.trr_tramitetarifa.First(a => a.ttr_id == ttrID);
                this.DBContext.trr_tramitetarifa.Remove(trr);
                this.DBContext.SaveChanges();
                this.cargarListBoxes();
                
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void undoChanges()
        {
            //foreach (DbEntityEntry entry in this.DBContext.ChangeTracker.Entries())
            //{
               
            //    switch (entry.State)
            //    {
            //        // Under the covers, changing the state of an entity from  
            //        // Modified to Unchanged first sets the values of all  
            //        // properties to the original values that were read from  
            //        // the database when it was queried, and then marks the  
            //        // entity as Unchanged. This will also reject changes to  
            //        // FK relationships since the original value of the FK  
            //        // will be restored. 
            //        case EntityState.Modified:
            //            entry.State = EntityState.Unchanged;
            //            break;
            //        case EntityState.Added:
            //            entry.State = EntityState.Detached;
            //            break;
            //        // If the EntityState is the Deleted, reload the date from the database.   
            //        case EntityState.Deleted:
            //            entry.Reload();
            //            break;
            //        default: break;
            //    }
            //}
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            this.btnAgregar.PerformClick();
        }

        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            this.btnQuitar.PerformClick();
        }
    }
}