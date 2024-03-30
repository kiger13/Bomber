using System.Collections;
using UnityEngine;

public class FollowBezierBomb : MonoBehaviour
{
    [SerializeField] private Transform _Point1;
    [SerializeField] private Transform _Point2;
    [SerializeField] private Transform _Point3;
    [SerializeField] private Transform _Point4;

    [SerializeField] private ExplosionBomb _Bomb;

    [Range(0, 1), SerializeField] private float _T;
    [SerializeField] private float _SpeedAnimation;
    [SerializeField] private float _DelayDestroy;


    private void OnValidate()
    {
        bool objectsExist = ObjectsExist();
        if (objectsExist == true)
            FollowingBezier();
    }

    private bool ObjectsExist()
    {
        if (_Point1 != null && _Point2 != null && _Point3 != null && _Point4 != null && _Bomb != null)
            return true;
        return false;
    }

    private void FollowingBezier()
    {
        _Bomb.transform.position = MathBezier.GetPoint(_Point1.position, _Point2.position, _Point3.position, _Point4.position, _T);
        _Bomb.transform.rotation = Quaternion.LookRotation(MathBezier.GetFirstDerivative(_Point1.position, _Point2.position, _Point3.position, _Point4.position, _T));
    }

    private void OnDrawGizmos()
    {

        int sigmentsNumber = 20;
        Vector3 preveousePoint = _Point1.position;

        for (int i = 0; i < sigmentsNumber + 1; i++)
        {
            float paremeter = (float)i / sigmentsNumber;
            Vector3 point = MathBezier.GetPoint(_Point1.position, _Point2.position, _Point3.position, _Point4.position, paremeter);
            Gizmos.DrawLine(preveousePoint, point);
            preveousePoint = point;
        }
    }

    public IEnumerator Followed()
    {
        transform.parent = null;

        while (_T < 1f) 
        {
            _T += Time.deltaTime * _SpeedAnimation;
            if (ObjectsExist())
            {
                FollowingBezier();
                yield return null;
            }
        }
        _Bomb.Exploding();
        _T = 0f;
    }
}