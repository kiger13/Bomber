using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public abstract class ExplosionBomb : MonoBehaviour, IAttacker
{
    [SerializeField] private float _Radius;
    [SerializeField] private float _Damage;

    [SerializeField] private ParticleSystem _Partical;

    public float Damage => _Damage;

    public void Exploding()
    {
        Debug.Log("анлаю б лнеи цпсдх");
        _Partical.Play();
    }

    public void Attack(List<IDamageable> damageable)
    {
        for (int i = 0; i < damageable.Count; i++)
        {
            damageable[i].ApplyDamage(Damage);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _Radius);
    }
}
