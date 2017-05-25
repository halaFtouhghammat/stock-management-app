//Name :hala ftouh ghammat
using App.Gwin.Attributes;
using App.Gwin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Entities
{

    [GwinEntity(Localizable = true, DisplayMember = "Name")]

    [Menu(Group = "Order")]
    public class configuration :BaseEntity

    {

        [DisplayProperty(Title = "TVA")]
        [EntryForm]
        [DataGrid]
        [Filter]

        public float TVA { get; set; }


        [DisplayProperty(Title = "RiskOfStock")]
        [EntryForm]
        [DataGrid]
        [Filter]

        public int RiskOfStock { get; set; }

        public configuration()
        {
            TVA = 20;
            RiskOfStock = 10;
        }


    }
}
