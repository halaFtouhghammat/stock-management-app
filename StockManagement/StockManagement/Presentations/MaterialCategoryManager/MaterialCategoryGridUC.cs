//Name:Hala ftouh ghammat
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
using StockManagement.BLL;
using StockManagement.DAL;

namespace StockManagement.Presentations.MaterialCategoryManager
{
    public partial class MaterialCategoryGridUC : UserControl
    {
        ModelContext db = new ModelContext();
        public MaterialCategoryGridUC()
        {
            InitializeComponent();
        }
        public event EventHandler EditerMaterialCategoryEvent;

        public MaterialCategory Currnt()
        {
            return (MaterialCategory)materialCategoryBindingSource.Current;
        }
        public void acctualisir()
        {
            materialCategoryBindingSource.Clear();
            materialCategoryBindingSource.DataSource = db.MaterialCategories.ToList<MaterialCategory>();



            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {

                dr.Cells[6].Value = new MaterialCategoryBLO().getMaterialNumbre(Convert.ToInt32(dr.Cells[0].Value));



                int val = Convert.ToInt32(dr.Cells[6].Value.ToString());
                if (val < 10)
                {
                    dr.DefaultCellStyle.BackColor = Color.Red;
                }

                }



            }

        private void MaterialCategoryGridUC_Load(object sender, EventArgs e)
        {
            acctualisir();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index && e.RowIndex >= 0)
            {

                if (DialogResult.Yes == MessageBox.Show(
                    "Voullez-vous vraimment supprimer ce Material Category",
                    "Confirmation de supprision", MessageBoxButtons.YesNo))
                {
                    MaterialCategory s = (MaterialCategory)materialCategoryBindingSource.Current;
                    db.MaterialCategories.Remove(s);

                    db.SaveChanges();
                    this.acctualisir();
                }


            }


            // Editer
            if (e.ColumnIndex == dataGridView1.Columns["Update"].Index && e.RowIndex >= 0)
            {

                EditerMaterialCategoryEvent(sender, e);
                this.acctualisir();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
           
            this.acctualisir();
        }
    }
}
