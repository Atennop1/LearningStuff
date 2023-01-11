using Photon.Pun;

namespace LearningStuff.Photon
{
    public class ServerConnector
    {
        public void ConnectToServer()
        {
            if (PhotonNetwork.IsConnected)
                return;
            
            PhotonNetwork.ConnectUsingSettings();
        }
    }
}
