using Photon.Pun;
using UnityEngine;

namespace LearningStuff.Photon.Callbacks
{
    public class ConnectCallback : MonoBehaviourPunCallbacks
    {
        public override void OnConnectedToMaster()
        {
            Debug.Log("Connected");
            
            if (!PhotonNetwork.InLobby)
                PhotonNetwork.JoinLobby();
        }
    }
}