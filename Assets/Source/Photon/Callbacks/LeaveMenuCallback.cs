using Photon.Pun;
using UnityEngine.SceneManagement;

namespace LearningStuff.Photon.Callbacks
{
    public class LeaveMenuCallback : MonoBehaviourPunCallbacks
    {
        public override void OnJoinedRoom() => SceneManager.LoadSceneAsync("PhotonGame");
    }
}