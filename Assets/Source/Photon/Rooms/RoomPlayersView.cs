using Photon.Pun;
using TMPro;
using UnityEngine;

namespace LearningStuff.Photon.Rooms
{
    public class RoomPlayersView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _playersText;

        public void Display()
        {
            Debug.Log("Displayed");
            _playersText.text =
                $"Players: {PhotonNetwork.CurrentRoom.PlayerCount}/{PhotonNetwork.CurrentRoom.MaxPlayers}";
        }
    }
}