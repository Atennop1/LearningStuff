using UnityEngine;

namespace LearningStuff.Photon
{
    public class MultiplayerRoot : MonoBehaviour
    {
        private void Awake()
        {
            var serverConnector = new ServerConnector();
            serverConnector.ConnectToServer();
        }
    }
}