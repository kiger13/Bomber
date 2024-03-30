using UnityEngine;

public interface IMovement
{
    public float Speed { get; }

    public void Moving(float speed);
}