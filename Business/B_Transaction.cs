using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class B_Transaction
    {
        public static List<TransactionEntity> OutputList()
        {
            using (var db = new InventoryContext())
            {
                return db.InOuts.ToList();
            }
        }

        public static void CreateOutput(TransactionEntity oOutput)
        {
            using (var db = new InventoryContext())
            {
                db.InOuts.Add(oOutput);
                db.SaveChanges();
            }
        }

        public static void UpdateOutput(TransactionEntity oOutput)
        {
            using (var db = new InventoryContext())
            {
                db.InOuts.Update(oOutput);
                db.SaveChanges();
            }
        }
    }
}
