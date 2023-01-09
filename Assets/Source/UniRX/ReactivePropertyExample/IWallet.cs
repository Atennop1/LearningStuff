using UniRx;

namespace LearningStuff.UniRX.ReactivePropertyExample
{
    public interface IWallet
    {
        IntReactiveProperty MoneyCount { get; }
        void Put(int money);
        
        void Take(int money);
        bool CanTake(int money);
    }
}