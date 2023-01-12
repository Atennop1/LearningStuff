using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LearningStuff.Photon.Rooms
{
    public class RoomView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _playersCountText;
        [SerializeField] private Button _joinRoomButton;

        public void Display(RoomInfo roomInfo)
        {
            _nameText.text = roomInfo.Name;
            _playersCountText.text = $"{roomInfo.PlayerCount}/{roomInfo.MaxPlayers}";
            
            _joinRoomButton.onClick.RemoveAllListeners();
            _joinRoomButton.onClick.AddListener(() => PhotonNetwork.JoinRoom(roomInfo.Name));
        }
    }
}