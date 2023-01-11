using Photon.Pun;
using UnityEngine;

namespace LearningStuff.Photon
{
    public class ServerConnectionTest : MonoBehaviourPunCallbacks
    {
        private void Awake()
        {
            var serverConnector = new ServerConnector();
            serverConnector.ConnectToServer();
        }

        public override void OnConnectedToMaster()
        {
            Debug.Log("Connected");
        }
    }
}