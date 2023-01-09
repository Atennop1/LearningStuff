using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace LearningStuff.UniRX.ReactivePropertyExample
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _moneyText;
        
        [Space]
        [SerializeField] private Button _addButton;
        [SerializeField] private Button _decreaseButton;
        [SerializeField] private Button _disposeButton;

        private readonly CompositeDisposable _disposable = new();

        private void Awake()
        {
            var wallet = new Wallet();
            
            wallet.MoneyCount
                .Subscribe(value => _moneyText.text = value.ToString())
                .AddTo(_disposable);
            
            _disposeButton.OnClickAsObservable()
                .Subscribe(_ => _disposable.Clear()).AddTo(_disposable);

            _addButton.OnClickAsObservable()
                .Subscribe(_ => wallet.Put(1)).AddTo(_disposable);

            _decreaseButton.OnClickAsObservable()
                .Subscribe(_ => wallet.Take(1)).AddTo(_disposable);
        }
    }
}