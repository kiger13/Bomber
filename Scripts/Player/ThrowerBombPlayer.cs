using UnityEngine;

public class ThrowerBombPlayer : MonoBehaviour
{
    [SerializeField] private PickerPlayer _Picker;
    [SerializeField] private Transform _DownPoint;

    private FollowBezierBomb Bomb => _Picker.PickBomb;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Bomb != null)
        {
            StartCoroutine(Bomb.Followed());
            _Picker.ClearBomb();
        }
    }
}