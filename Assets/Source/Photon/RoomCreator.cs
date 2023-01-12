using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace LearningStuff.Photon
{
    public class RoomCreator
    {
        public void CreateRoom(string name, TypedLobby lobby, byte maxPlayersCount)
        {
            if (!PhotonNetwork.IsConnected)
                return;
            
            var roomOptions = new RoomOptions
            {
                MaxPlayers = maxPlayersCount
            };
                
            PhotonNetwork.CreateRoom(name, roomOptions, lobby);
            Debug.Log($"Room with name {name} created");
        }
    }
}