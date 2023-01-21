using LearningStuff.Photon.Chat;
using Photon.Pun;
using UnityEngine;

namespace LearningStuff.Photon.Callbacks
{
    public class CreateRoomCallback : MonoBehaviourPunCallbacks
    {
        [SerializeField] private MessageWriter _messageWriter;
        
        public override void OnCreatedRoom()
        {
            Debug.Log("Room created");
            _messageWriter.WriteMessage(new Message("SYSTEM", 
                $"Room {PhotonNetwork.CurrentRoom.Name} created by player {PhotonNetwork.NickName}"));
        }
    }
}