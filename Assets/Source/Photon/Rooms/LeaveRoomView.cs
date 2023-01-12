using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace LearningStuff.Photon.Rooms
{
    public class LeaveRoomView : MonoBehaviour
    {
        [SerializeField] private Button _leaveButton;

        private void Awake()
        {
            _leaveButton.onClick.AddListener(() => PhotonNetwork.LeaveRoom());
        }
    }
}