using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LearningStuff.Photon.Rooms
{
    public class RoomCreatorView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _nameInputField;
        [SerializeField] private Button _createRoomButton;

        private void Awake()
        {
            var roomCreator = new RoomCreator();

            _createRoomButton.onClick.AddListener(() =>
            {
                if (_nameInputField.text == string.Empty)
                    return;
                
                roomCreator.CreateRoom(_nameInputField.text, TypedLobby.Default, 2);
                PhotonNetwork.JoinRoom(_nameInputField.text);
            });
        }
        
    }
}