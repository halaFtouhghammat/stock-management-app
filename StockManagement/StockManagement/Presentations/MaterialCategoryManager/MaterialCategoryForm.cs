//hala ftouh ghammat
using StockManagement.DAL;
using StockManagement.Entities;
using StockManagement.Presentations.MaterialCategoryManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StockManagement.Presentations.RiskOFStock.MaterialCategoryRiskOfStock
{

    [App.Gwin.Attributes.Menu(EntityType = typeof(MaterialCategory), Order = 10, Title = "Add Material Category")]
    public partial class MaterialCategoryForm :MetroFramework.Forms.MetroForm
    {
        ModelContext db = new ModelContext();
        //[Menu(Group ="Societe")]
        // ModelContext db = new ModelContext();
        public MaterialCategoryForm()
        {
            InitializeComponent();
        }

        private void MaterialCategoryForm_Load(object sender, EventArgs e)
        {


     MaterialCategoryGridUC uc = new MaterialCategoryGridUC();
            // uc.Dock = DockStyle.Fill;
            // this.Controls.Add(uc);
            tabControl1.TabPages["tabPage1"].Controls.Add(uc);

            //this.da.Rows.Add();
            //this.dataGridView1.Rows[0].Cells[1].Value = "1";

            uc.EditerMaterialCategoryEvent += uc_EditerMaterialCategoryEvent;

           
        }

        private void uc_EditerMaterialCategoryEvent(object sender, EventArgs e)
        {
            List<Control> materialcategoryGrids = new List<Control>(); materialcategoryGrids.Add(tabControl1.TabPages["tabPage1"].Controls.Find("MaterialCategoryGridUC", true)[0]); 
              MaterialCategory materialcategory = new MaterialCategory();
           MaterialCategoryGridUC materialcategorys = (MaterialCategoryGridUC)materialcategoryGrids[0];
            materialcategory = materialcategorys.Currnt();
          //  
            string tabEditerName = "TabEditer-" + materialcategory.Id;

            if (tabControl1.TabPages.IndexOfKey(tabEditerName) == -1)
            {
                // Création de Tab
                TabPage tabEditerGroup = new TabPage();
                tabEditerGroup.Text = materialcategory.Description.Current;
                tabEditerGroup.Text = materialcategory.Designation.Current;
                tabEditerGroup.Name = tabEditerName;
                tabControl1.TabPages.Add(tabEditerGroup);
                tabControl1.SelectedTab = tabEditerGroup;

                // Insertion du formulaire 
                MaterialCategoryUC materialcategoryUC = new MaterialCategoryUC();
                materialcategoryUC.Name = "materialcategoryUC";
                materialcategoryUC.materialcategory = materialcategory;
                materialcategoryUC.afficher();
                this.tabControl1.TabPages[tabEditerName].Controls.Add(materialcategoryUC);
                materialcategoryUC.EnregistrerClick += materialcategoryUC_EditerClick;
                materialcategoryUC.AnnulerClick += materialcategoryUC_AnnulerEditerClick;
            }
      // new   MaterialCategoryGrid().acctualisir();

    }

        private void materialcategoryUC_AnnulerEditerClick(object sender, EventArgs e)
        {
            MaterialCategoryUC materialcategoryUC = (MaterialCategoryUC)sender;
            MaterialCategory materialcategory = materialcategoryUC.materialcategory;
            string tabEditerName = "TabEditer-" + materialcategory.Id;
            TabPage tabEditer = this.tabControl1.TabPages[tabEditerName];
            tabControl1.TabPages.Remove(tabEditer);
        }

        private void materialcategoryUC_EditerClick(object sender, EventArgs e)
        {
            MaterialCategoryUC materialcategoryUC = (MaterialCategoryUC)sender;
                MaterialCategory materialcategory = materialcategoryUC.materialcategory;
                string tabEditerName = "TabEditer-" + materialcategory.Id;
                TabPage tabEditer = this.tabControl1.TabPages[tabEditerName];
                db.MaterialCategories.Attach(materialcategoryUC.materialcategory);
                if (db.SaveChanges() > 0)
                {
                    MessageBox.Show("Le Material :" + materialcategory.ToString() + " a été bien enregistrer");
                }
                else
                {
                  //  MessageBox.Show("Le Material :" + materialcategory.ToString() + " n'est pas enregistrer car il n'y a pas des modification");
                }


                // Suppression de la page Editer
                this.tabControl1.TabPages.Remove(tabEditer);

           new MaterialCategoryGridUC().acctualisir();

            }

        private void metroTile1_Click(object sender, EventArgs e)
        {
                  if (tabControl1.TabPages.IndexOfKey("TabAjouter") == -1)
                      {
                // Création de Tab
                TabPage tabAjouterGroup = new TabPage();
                tabAjouterGroup.Text = "Ajouter un Material";
                tabAjouterGroup.Name = "TabAjouter";
                tabControl1.TabPages.Add(tabAjouterGroup);
                tabControl1.SelectedTab = tabAjouterGroup;

                // Insertion du formulaire 
                MaterialCategoryUC materialcategoryUC = new MaterialCategoryUC();
                materialcategoryUC.Name = "materialcategoryUC";
                this.tabControl1.TabPages["TabAjouter"].Controls.Add(materialcategoryUC);
                materialcategoryUC.EnregistrerClick += materialcategoryUC_EnregistrerClick;
                materialcategoryUC.AnnulerClick += materialcategoryUC_AnnulerAjouterClick;
            }
        }

        private void materialcategoryUC_AnnulerAjouterClick(object sender, EventArgs e)
        {
         

            TabPage tabAjouter = this.tabControl1.TabPages["TabAjouter"];
     tabControl1.TabPages.Remove(tabAjouter);
        }

        private void materialcategoryUC_EnregistrerClick(object sender, EventArgs e)
        {
            TabPage tabAjouter = this.tabControl1.TabPages["TabAjouter"];
            MaterialCategoryUC materialcategoryUC = (MaterialCategoryUC)tabAjouter.Controls
                 .Find("MaterialCategoryUC", false).First();
            db.MaterialCategories.Add(materialcategoryUC.materialcategory);
            if (db.SaveChanges() > 0)
            {
                MessageBox.Show("Le Material:" + materialcategoryUC.materialcategory.ToString() + " a été bien enregistrer");
            }
            else
            {
                MessageBox.Show("Le Material :" + materialcategoryUC.materialcategory.ToString() + " n'est pas enregistrer");
            }

            this.tabControl1.TabPages.Remove(tabAjouter);

          new   MaterialCategoryGridUC().acctualisir();
        }

      
    }
    
}
      

   
