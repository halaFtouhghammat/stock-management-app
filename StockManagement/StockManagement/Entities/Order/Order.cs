 //  Name : hala ftouh ghammat
using App.Gwin.Attributes;
using App.Gwin.Entities;
using StockManagement.Entities.Resources.Societe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Entities
{
    [GwinEntity(Localizable = true, DisplayMember = "Name")]
    [Menu(Group = "Order")]
    public class Order :BaseEntity
    {
        [DisplayProperty(Title = "Name")]
        [EntryForm]
        [DataGrid]
        [Filter]
        public string Name { get; set; }

        [DisplayProperty(Title = "orderDate")]
        [EntryForm]
        [DataGrid]
        [Filter]
        public DateTime orderDate { get; set; }

        [DisplayProperty(Title = "DeliveryDateExpected")]
        [EntryForm]
        [DataGrid]
        [Filter]
        public DateTime DeliveryDateExpected { get; set; }

        //[Relationship(Relation = RelationshipAttribute.Relations.ManyToOne)]
        //[EntryForm]
        //[Filter]
        //[DataGrid(WidthColonne = 100)]
        //public Societe societe { get; set; }

        public string OrderState { get; set; }


        //Initialisier Datetime
        public Order()
        {
            this.DeliveryDateExpected = DateTime.Now;
            this.orderDate = DateTime.Now;
        }
    }
}
