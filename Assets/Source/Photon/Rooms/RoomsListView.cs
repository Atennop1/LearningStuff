using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace LearningStuff.Photon.Rooms
{
    public class RoomsListView : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Transform _content;
        [SerializeField] private GameObject _roomViewPrefab;

        public override void OnRoomListUpdate(List<RoomInfo> roomInfos) => Display(roomInfos);
        
        private void Display(List<RoomInfo> roomInfos)
        {
            ClearContent();

            foreach (var roomInfo in roomInfos)
            {
                var roomViewGameObject = Instantiate(_roomViewPrefab, _content);
                var roomView = roomViewGameObject.GetComponent<RoomView>();
                roomView.Display(roomInfo);
            }
        }

        private void ClearContent()
        {
            for (var i = 0; i < _content.childCount; i++)
                Destroy(_content.GetChild(i).gameObject);
        }
    }
}