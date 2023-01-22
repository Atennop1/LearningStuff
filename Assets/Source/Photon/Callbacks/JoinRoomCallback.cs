using LearningStuff.Photon.Chat;
using LearningStuff.Photon.Rooms;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace LearningStuff.Photon.Callbacks
{
    public class JoinRoomCallback : MonoBehaviourPunCallbacks
    {
        [SerializeField] private PhotonView _photonView;
        [SerializeField] private MessageWriter _messageWriter;
       [SerializeField] private RoomPlayersView _roomPlayersView;
       
       public override void OnPlayerEnteredRoom(Player newPlayer)
       {
           _photonView.RPC("DisplayPlayers", RpcTarget.All);
           WriteMessage($"{newPlayer.NickName} has joined the room");
       }

       public override void OnJoinedRoom()
       {
           _photonView.RPC("DisplayPlayers", RpcTarget.All);
           WriteMessage($"{PhotonNetwork.NickName} has joined the room");
       }

       [PunRPC]
       private void DisplayPlayers()
           => _roomPlayersView.Display();

       private void WriteMessage(string message)
           => _messageWriter.WriteMessage(new Message("SYSTEM", message));
    }
}