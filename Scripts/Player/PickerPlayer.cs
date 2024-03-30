using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickerPlayer : MonoBehaviour
{
    [SerializeField] private Transform _PickPoint;

    private FollowBezierBomb _PickBomb;

    public FollowBezierBomb PickBomb => _PickBomb;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out FollowBezierBomb fallBomb) && _PickBomb == null)
        {
            _PickBomb = fallBomb;
            PickingBomb(_PickBomb);
        }
    }

    public void ClearBomb()
    {
        _PickBomb = null;
    }

    private void PickingBomb(FollowBezierBomb fallBomb)
    {
        fallBomb.transform.position = _PickPoint.position;
        fallBomb.transform.rotation = _PickPoint.rotation;
        fallBomb.transform.parent = _PickPoint;
    }
}

