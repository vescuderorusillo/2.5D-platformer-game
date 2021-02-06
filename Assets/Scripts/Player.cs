using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField]
    private float _speed = 5f;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var direction = new Vector3(horizontalInput, 0, 0);

        var velocity = direction * _speed;
        _controller.Move(velocity * Time.deltaTime);
    }
}
