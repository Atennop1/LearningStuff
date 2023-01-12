using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LearningStuff.Photon
{
    public class PhotonCallbacks : MonoBehaviourPunCallbacks
    {
        public override void OnConnectedToMaster()
        {
            Debug.Log("Connected");
            
            if (!PhotonNetwork.InLobby)
                PhotonNetwork.JoinLobby();
        }

        public override void OnJoinedRoom() => SceneManager.LoadSceneAsync("PhotonGame");

        public override void OnLeftRoom() => SceneManager.LoadSceneAsync("PhotonMenu");
    }
}