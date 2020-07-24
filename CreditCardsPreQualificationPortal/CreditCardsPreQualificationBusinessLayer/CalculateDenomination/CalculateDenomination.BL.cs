namespace CreditCardsPreQualificationBusinessLayer.CalculateDenomination
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CalculateDenomination
    {
        public const int POUNDDENOMINATIONS = 12;
        public float[] CurrencyList = new float[POUNDDENOMINATIONS] { 50, 20, 10, 5, 2, 1, .5F, .2F, .1F, .05F, .02F, .01F };
        public IEnumerable<Change> GetListOfDenominations(Billpayment payment)
        {

            List<Change> listofChanges = new List<Change>();
            float balanceAmount = payment.GivenAmount - payment.ProductPrice;
            if (balanceAmount > 0)
            {

                for (int i = 0; i < CurrencyList.Count(); i++)
                {
                    Change _change = new Change();
                    if (CurrencyList[i] > balanceAmount)
                    {
                        // No need to consider as this amount is greater than the balance to be returned.
                        continue;
                    }

                    int count = (int)(balanceAmount / CurrencyList[i]);
                    _change.change = CurrencyList[i];
                    _change.denomination = count;

                    float netBalance = balanceAmount % CurrencyList[i];
                    netBalance = (float)Math.Round(netBalance, 2);
                    listofChanges.Add(_change);
                    if (netBalance == 0)
                    {
                        break;
                    }
                    balanceAmount = netBalance;
                }

            }
            return listofChanges;
        }

    }
}

