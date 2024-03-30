using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent((typeof(Rigidbody)))]
public class MovementPlayer : MonoBehaviour, IMovement
{
    [SerializeField] private float _Speed;

    private Vector3 _Direction;
    private Rigidbody _Rb;

    public float Speed => _Speed;


    private void Awake()
    {
        _Rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        _Direction = new Vector3 (horizontal, 0f, vertical).normalized;
        Moving(Speed);
    }

    public void Moving(float speed)
    {
        _Rb.MovePosition(_Rb.position + _Direction * speed * Time.deltaTime);

        if (_Direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(_Direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.15f); // Плавный поворот
        }
    }
}
