using Photon.Pun;
using UnityEngine.SceneManagement;

namespace LearningStuff.Photon.Callbacks
{
    public class LeaveRoomCallback : MonoBehaviourPunCallbacks
    {
        public override void OnLeftRoom() 
            => SceneManager.LoadSceneAsync("PhotonMenu");
    }
}