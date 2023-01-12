using TMPro;
using UnityEngine;

namespace LearningStuff.Photon.Chat
{
    public class MessageView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _messageText;

        public void Display(Message message)
        {
            _messageText.text = $"{message.Nickname}: {message.Text}";
        }
    }
}