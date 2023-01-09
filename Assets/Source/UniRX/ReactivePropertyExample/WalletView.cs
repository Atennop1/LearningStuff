using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace LearningStuff.UniRX.ReactivePropertyExample
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _moneyText;
        [SerializeField] private Button _addButton;
        [SerializeField] private Button _decreaseButton;

        private void Awake()
        {
            var wallet = new Wallet();
            wallet.MoneyCount.Subscribe(value => _moneyText.text = value.ToString());

            _addButton.OnClickAsObservable()
                .Subscribe(_ => wallet.Put(1));

            _decreaseButton.OnClickAsObservable()
                .Subscribe(_ => wallet.Take(1));
        }
    }
}