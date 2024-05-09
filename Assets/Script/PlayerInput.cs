using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private InputControl _inputControl;
    [SerializeField]
    private PlayerController _playerController;

    private void Awake()
    {
        _inputControl = new InputControl();
        _inputControl.Player.Move.performed += OnMove;

    }

    private void OnEnable()
    {
        _inputControl.Enable();
    }

    private void OnMove(InputAction.CallbackContext obj)
    {
        _playerController.Move();
    }

    private void OnDisable()
    {
        _inputControl.Disable();
    }

    private void OnDestroy()
    {
        _inputControl.Player.Move.performed -= OnMove;
    }
}
