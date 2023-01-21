using LearningStuff.Photon.Chat;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace LearningStuff.Photon.Callbacks
{
    public class JoinRoomCallback : MonoBehaviourPunCallbacks
    {
       [SerializeField] private MessageWriter _messageWriter;
       
       public override void OnPlayerEnteredRoom(Player newPlayer)
       {
           Debug.Log("Other joined the room");
           WriteMessage($"{newPlayer.NickName} has joined the room");
       }

       public override void OnJoinedRoom()
       {
           Debug.Log("You joined the room");
           WriteMessage($"{PhotonNetwork.NickName} has joined the room");
       }

       private void WriteMessage(string message)
           => _messageWriter.WriteMessage(new Message("SYSTEM", message));
    }
}