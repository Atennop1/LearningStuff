using Cysharp.Threading.Tasks;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace LearningStuff.Photon
{
    public class RoomCreationTest : MonoBehaviourPunCallbacks
    {
        [SerializeField] private byte _maxPlayersCount;
        [SerializeField] private string _roomName;
        [SerializeField] private TypedLobby _lobby;

        public async void Awake()
        {
            var serverConnector = new ServerConnector();
            serverConnector.ConnectToServer();

            await UniTask.Delay(3000);

            var roomCreator = new RoomCreator();
            roomCreator.CreateRoom(_roomName, _lobby, _maxPlayersCount);
        }

        public override void OnCreatedRoom()
        {
            Debug.Log("Room created");
        }
    }
}