using System;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _movementVelocity;
    [SerializeField] private SpriteRenderer _aimSprite;
    [SerializeField] private PlayerRotator _playerRotator;
    [SerializeField] private UserMoveTimerLimiter _userMoveTimerLimiter;
    [SerializeField] private AudioSource _moveAudioClip;
    [SerializeField] private ParticleSystem _deathParticlesPrefab;

    private Vector3 _startPosition;
    private bool _isMoving;

    public void Awake()
    {
        _startPosition = transform.position;
        _isMoving = false;
    }

    [UsedImplicitly]
    public void OnPlayerDied() // Вызывается по ивенту смерти игрока.
    {
        Instantiate(_deathParticlesPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    [UsedImplicitly]
    public void Move() // Вызывается через колбэк нажатия кнопки передвижения.
    {
        if (!_isMoving)
        {
            _isMoving = !_isMoving;
            _aimSprite.enabled = false;
            _playerRotator.StopRotation();
            _userMoveTimerLimiter.StopTimeLimiter();
            _moveAudioClip.Play();
            
            _rigidbody.velocity = transform.up * _movementVelocity;
        }
    }

    [UsedImplicitly]
    public void ChangeDirection() // Вызываем через ивент, при колизии игрока с врагом.
    {
        _rigidbody.velocity *= -1;
    }

    [UsedImplicitly]
    public void ResetPosition() // Вызываем через ивент при возвращении игрока в старт поинт триггер.
    {
        if (_isMoving)
        {
            _isMoving = !_isMoving;
            _aimSprite.enabled = true;
            _playerRotator.StartRotation();
            _userMoveTimerLimiter.RestartTimeLimiter();
            
            _rigidbody.velocity = Vector2.zero;
            transform.position = _startPosition;
        }
    }
}
