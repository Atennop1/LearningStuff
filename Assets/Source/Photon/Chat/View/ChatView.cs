using System.Collections.Generic;
using UnityEngine;

namespace LearningStuff.Photon.Chat
{
    public class ChatView : MonoBehaviour
    {
        [SerializeField] private Transform _content;
        [SerializeField] private GameObject _messagePrefab;

        public void Display(List<Message> messages)
        {
            ClearContent();

            foreach (var message in messages)
            {
                var messageGameObject = Instantiate(_messagePrefab, _content);
                var messageView = messageGameObject.GetComponent<MessageView>();
                messageView.Display(message);
            }
        }

        private void ClearContent()
        {
            for (var i = 0; i < _content.childCount; i++)
                Destroy(_content.GetChild(i).gameObject);
        }
    }
}