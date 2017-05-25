//Name :hala ftouh ghammat
using App.Gwin.Attributes;
using App.Gwin.Entities;
using StockManagement.Entities.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Entities
{
    
    [GwinEntity(Localizable = true, DisplayMember = "Quantity")]
    [Menu(Group = "Order")]
    public class OrderLine :BaseEntity
    {
        [DisplayProperty(Title = "Quantity")]
        [EntryForm]
        [DataGrid]
        [Filter]
        public float Quantity { get; set; }

        [Relationship(Relation = RelationshipAttribute.Relations.ManyToOne)]
        [EntryForm]
        [Filter]
        [DataGrid(WidthColonne = 100)]
        public Material material { get; set; }

    }
}
