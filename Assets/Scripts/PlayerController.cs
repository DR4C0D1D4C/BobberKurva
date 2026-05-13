using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed;

    CharacterController _characterController;
    CharacterControllerInputs _playerInput;

    Vector2 _currentMovementInput;
    Vector2 _currentMovement;
    bool _isMovementPressed;

    void Awake()
    {
        _playerInput = new CharacterControllerInputs();
        _characterController = GetComponent<CharacterController>();

        _playerInput.Player.Move.started += OnMovementInput;
        _playerInput.Player.Move.canceled += OnMovementInput;
        _playerInput.Player.Move.performed += OnMovementInput;
    }

    void Update()
    {
        HandleRotarion();
        _characterController.Move(_currentMovement * Time.deltaTime);
    }

    void HandleRotarion()
    {
        Quaternion currentRotation = transform.rotation;

        if (_isMovementPressed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, _currentMovementInput);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, 1);
        }
    }

    void OnMovementInput(InputAction.CallbackContext context)
    {
        _currentMovementInput = context.ReadValue<Vector2>();
        _currentMovement.x = _currentMovementInput.x * _speed;
        _currentMovement.y = _currentMovementInput.y * _speed;
        _isMovementPressed = _currentMovementInput.x != 0 || _currentMovementInput.y != 0;
    }

    void OnEnable()
    {
        _playerInput.Player.Enable();
    }

    void OnDisable()
    {
        _playerInput.Player.Disable();
    }
}
