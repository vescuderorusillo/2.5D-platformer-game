using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField]
    private float _speed = 5f;

    [SerializeField]
    private float _gravity = 1.0f;

    [SerializeField]
    private float _jumpHeight = 25.0f;

    private float _yVelocity;

    private bool _canDoubleJump;

    [SerializeField]
    private int _coins;

    private UIManager _uiManager;

    [SerializeField]
    private int _lives = 3;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        _uiManager.UpdateLivesDisplay(_lives);
    }

    private void Update()
    {
        CalculateMovement();
    }

    public void AddCoins()
    {
        _coins++;
        _uiManager.UpdateCoinDisplay(_coins);
    }

    private void CalculateMovement()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var direction = new Vector3(horizontalInput, 0, 0);

        var velocity = direction * _speed;

        if (_controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }
        }
        else
        {
            if (_canDoubleJump && Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _canDoubleJump = false;
            }
            _yVelocity -= _gravity;
        }

        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);
    }

    public void Damage()
    {
        _lives--;
        _uiManager.UpdateLivesDisplay(_lives);

        if (_lives < 1)
        {
            SceneManager.LoadScene(0);
        }
    }
}
