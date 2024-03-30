using System.Collections.Generic;

public interface IAttacker
{
    public float Damage { get; }

    public void Attack(List<IDamageable> damageable);
}