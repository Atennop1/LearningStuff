using LearningStuff.Photon.Chat;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LearningStuff.Photon.Callbacks
{
    public class JoinRoomCallback : MonoBehaviourPunCallbacks
    {
       [SerializeField] private MessageWriter _messageWriter;

       public override void OnJoinedRoom()
       {
           Debug.Log("join");
           _messageWriter.WriteMessage(
               new Message("SYSTEM", $"{PhotonNetwork.NickName} has joined the room"));
       }
    }
}