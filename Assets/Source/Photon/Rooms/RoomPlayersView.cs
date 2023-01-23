using Photon.Pun;
using TMPro;
using UnityEngine;

namespace LearningStuff.Photon.Rooms
{
    public class RoomPlayersView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _playersText;

        private void FixedUpdate()
        {
            if (!PhotonNetwork.IsConnected || PhotonNetwork.CurrentRoom == null)
                return;
            
            _playersText.text =
                $"Players: {PhotonNetwork.CurrentRoom.PlayerCount}/{PhotonNetwork.CurrentRoom.MaxPlayers}";
        }
    }
}