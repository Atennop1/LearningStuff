using Photon.Pun;

namespace LearningStuff.Photon
{
    public class MultiplayerRoot : MonoBehaviourPunCallbacks
    {
        private void Awake()
        {
            var serverConnector = new ServerConnector();
            serverConnector.ConnectToServer();
        }
    }
}