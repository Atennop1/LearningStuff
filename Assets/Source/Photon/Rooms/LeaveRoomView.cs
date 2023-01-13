using LearningStuff.Photon.Chat;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace LearningStuff.Photon.Rooms
{
    public class LeaveRoomView : MonoBehaviour
    {
        [SerializeField] private MessageWriter _messageWriter;
        [SerializeField] private Button _leaveButton;

        private void Awake()
        {
            _leaveButton.onClick.AddListener(() =>
            {
                _messageWriter.WriteMessage(
                    new Message("SYSTEM", $"{PhotonNetwork.NickName} has left the room"));
                
                PhotonNetwork.LeaveRoom();
            });
        }
    }
}