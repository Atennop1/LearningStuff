using System;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LearningStuff.Photon.Chat
{
    public class NicknameSetterView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _nickInputField;
        [SerializeField] private Button _saveButton;

        private void Awake()
        {
            _saveButton.onClick.AddListener(() =>
            {
                if (_nickInputField.text == string.Empty)
                    return;

                PhotonNetwork.NickName = _nickInputField.text;
            });
        }
    }
}