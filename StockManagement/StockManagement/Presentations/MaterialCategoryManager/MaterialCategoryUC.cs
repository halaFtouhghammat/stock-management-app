//Name:hala ftouh ghammat
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockManagement.Entities;
using App.Gwin.Entities.MultiLanguage;

namespace StockManagement.Presentations.MaterialCategoryManager
{
    public partial class MaterialCategoryUC : UserControl
    {
        public MaterialCategoryUC()
        {
            InitializeComponent();
        }
        public event EventHandler EnregistrerClick;
        public event EventHandler AnnulerClick;
        public MaterialCategory materialcategory { set; get; }

        public void afficher()
        {
            DescriptiontextBox.Text = materialcategory.Description.Current;
            DesignationtextBox.Text = materialcategory.Designation.Current;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (this.materialcategory == null) materialcategory = new MaterialCategory();
            materialcategory.Description = new LocalizedString();
            materialcategory.Description.Current = DescriptiontextBox.Text;

            materialcategory.Designation = new LocalizedString();
            materialcategory.Designation.Current = DesignationtextBox.Text;
            EnregistrerClick(this, e);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AnnulerClick(this, e);
        }
    }
    }
