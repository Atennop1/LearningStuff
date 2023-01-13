using System;
using UniRx;

namespace LearningStuff.UniRX.ReactivePropertyExample
{
    public class Wallet
    {
        public IntReactiveProperty MoneyCount { get; } = new();
        
        public void Put(int money)
        {
            if (money <= 0)
                throw new ArgumentException("Can't put negative number or zero money to wallet");

            MoneyCount.Value += money;
        }

        public void Take(int money)
        {
            if (money <= 0)
                throw new ArgumentException("Can't take negative number or zero money from wallet");
            
            if (!CanTake(money))
                throw new ArgumentException("You are trying to take too much money");

            MoneyCount.Value -= money;
        }

        private bool CanTake(int money) => money <= MoneyCount.Value;
    }
}