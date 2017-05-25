// hala Ftouh ghammat 

using StockManagement.BAL;
using StockManagement.DAL;
using StockManagement.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.BLL
{
    /// <summary>
    /// fr : Gestion des Categoriy de materiels
    /// en : Materials Categries Management
    /// </summary>
    public class MaterialCategoryBLO : BaseBLO<MaterialCategory>
    {
        ModelContext db = new ModelContext();

        public MaterialCategoryBLO(DbContext context) : base(context)
        {
        }

        public MaterialCategoryBLO() : base()
        {
        }
               public int getMaterialNumbre(int id)
        {
            var query = from mc in db.MaterialCategories
                        join m in db.Materials
                        on mc.Id equals m.Materialcategory.Id
                        where mc.Id == id
                        select new

                        {
                            // Count( m.InventoryNumber),
                            mc.Designation,
                            mc.Description,
                            mc.DateCreation,
                            mc.DateModification,
                        };
            return query.ToList().Count();
        }
    }
}
