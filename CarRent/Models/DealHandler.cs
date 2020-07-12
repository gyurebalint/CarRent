using CarRent.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.Models
{
    class DealHandler : DbHandler
    {
        private void CheckErrors(Deal deal)
        {
            string errors = "";

        }

        public void SetDealWithCkeck(Deal deal)
        {
            CheckErrors(deal);
            SetDeal(deal);
        }

        public void UpdateWithCheck(Deal deal)
        {
            CheckErrors(deal);
            UpdateDeal(deal);
        }
    }
}
