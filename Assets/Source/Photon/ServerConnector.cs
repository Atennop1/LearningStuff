using Photon.Pun;

namespace LearningStuff.Photon
{
    public class ServerConnector
    {
        public void ConnectToServer() => PhotonNetwork.ConnectUsingSettings();
    }
}