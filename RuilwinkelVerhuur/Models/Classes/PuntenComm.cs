using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuilwinkelVerhuur.Models.Classes
{
    public class PuntenComm
    {
        //Retrieve wallet balance form puntenbeheer with wallet id number
        public static int RetrieveBalance(int walletID)
        {
            //TODO ask punten for saldo based obn walletID
            return 35;
        }

        //Send request to puntenbeheer to subtract cost form wallet with walletID
        public static bool SubstractPoints(int walletID, int cost)
        {
            //ask punten to substract x points
            return true;
        }

        //Send request to puntenbeheer to add cost to wallet with walletID
        public static bool RefundProduct(ProductNaarFactuur product, int cost, int walletID)
        {
            //if(product.StartDate < current date)
            //TODO Refund points and set product to available
            return true;
        }

        //Send request to add points according to all products within factuur to wallet with walletID
        public static bool RefundOrder(Factuur order, int walletID)
        {
            return true;
        }
    }
}
