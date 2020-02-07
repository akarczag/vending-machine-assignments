using System;
using System.Collections.Generic;
using System.Text;

namespace Ex_4._2_Coins
{
    class Coin
    {
        public enum Coins { COIN = 0, PENNY = 1, NICKEL = 5, DIME = 10, QUARTER = 25 };

        private Coins userCoin;

        // this is the default coin type if nothing is passed from the user
        public Coin()
        {
            userCoin = Coins.COIN;
        }

        // this is the coin type passed from the user
        public Coin(Coins coinType)
        {
            userCoin = coinType;
        }

        // this turns the user input into a value from the enum
        public Coin(string coinName)
        {
            string[] coinInput = Enum.GetNames(typeof(Coins));
            bool isCoinName = false;

            foreach (string coinIn in coinInput)
            {
                if (coinIn.Equals(coinName)) isCoinName = true;
            }

            Coins coinTypeof;
            if (Enum.IsDefined(typeof(Coins), coinName) && isCoinName == true
                && Enum.TryParse<Coins>(coinName, out coinTypeof))
            {
                userCoin = coinTypeof;
            }
            else
            {
                userCoin = Coins.COIN;
            }
        }

        // this turns the coin into monetary value
        public Coin(decimal CoinValue)
        {
            Coins castFromValue = (Coins)(CoinValue * 100);
            switch (castFromValue)
            {
                case Coins.PENNY:
                case Coins.NICKEL:
                case Coins.DIME:
                case Coins.QUARTER:
                    userCoin = castFromValue;
                    break;
                default:
                    userCoin = Coins.COIN;
                    break;
            }
        }

        //  This property will get the monetary value of the coin.
        public decimal ValueOf
        {
            get
            {
                return (decimal)userCoin / 100M;
            }
        }

        //  This property will get the coin name as an enumeral
        public Coins coinEnum
        {
            get
            {
                return userCoin;
            }
        }

        // get the coins as a string
        public override string ToString()
        {
            return Enum.GetName(typeof(Coins), userCoin);
        }
    }
}
