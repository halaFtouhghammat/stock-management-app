﻿using App.Gwin;
using App.Gwin.Application.Presentation.EntityManagement;
using App.Gwin.Entities.Secrurity.Authentication;
using StockManagement.BAL;
using StockManagement.BLL;
using StockManagement.DAL;
using System;
using System.Windows.Forms;

namespace StockManagement
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void locationManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagerForm form = new ManagerForm(new LocationsBLO(), null, this);
            this.IsMdiContainer = true;
            form.MdiParent = this;
            form.Show();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            // Start Gwin Application with Authentification
            User user = null;

            user = User.CreateRootUser(new ModelContext());
            user.Language = GwinApp.Languages.fr;
            GwinApp.Start(typeof(ModelContext), typeof(BaseBLO<>), null, user);

            //Form Aggrandize
            this.WindowState = FormWindowState.Maximized;
        }

        private void serviceManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagerForm form = new ManagerForm(new ServicesBLO(), null, this);
            this.IsMdiContainer = true;
            form.MdiParent = this;
            form.Show();
        }

        private void personnesManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagerForm form = new ManagerForm(new PersonnesBLO(), null, this);
            this.IsMdiContainer = true;
            form.MdiParent = this;
            form.Show();
        }

        private void materialsCategoryManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagerForm form = new ManagerForm(new MaterialsCategoriesBLO(), null, this);
            this.IsMdiContainer = true;
            form.MdiParent = this;
            form.Show();
        }

        private void materialsManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FormGestionMateriel f = new FormGestionMateriel();
            //ManagerForm form = new ManagerForm(new BaseBLO<Material>(), null, this);
            //this.IsMdiContainer = true;
            //f.MdiParent = this;
            //f.Show();
        }
    }
}
