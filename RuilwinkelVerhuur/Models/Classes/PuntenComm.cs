using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuilwinkelVerhuur.Models.Classes
{
    public class PuntenComm
    {
        public static int RetrieveBalance(int walletID)
        {
            //TODO ask punten for saldo based obn walletID
            return 35;
        }

        public static bool SubstractPoints(int walletID, int cost)
        {
            //ask punten to substract x points
            return true;
        }

        public static bool RefundProduct(ProductNaarFactuur product)
        {
            //if(product.StartDate < current date)
            //TODO Refund points and set product to available
            return true;
        }

        public static bool RefundOrder(Factuur order)
        {
            return true;
        }
    }
}
