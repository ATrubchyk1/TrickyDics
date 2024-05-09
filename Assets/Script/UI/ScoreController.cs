using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreLable;
    [SerializeField] private int _rewardPerEnemy;
    [SerializeField] private float _animationDuration;
    [SerializeField] private float _scaleFactor;
    [SerializeField] private AudioSource _scoreChangeAudioClip;
    
    private int _score;

    [UsedImplicitly]
    public void AddScore() // Вызывается по ивенту, когда игрок уничтожил врага.
    {
        _score += _rewardPerEnemy;
        _scoreChangeAudioClip.Play();
        _scoreLable.text = _score.ToString();
        _scoreLable.transform.DOPunchScale(Vector3.one * _scaleFactor, _animationDuration, 0)
            .OnComplete(() => _scoreLable.transform.localScale = Vector3.one);
    }

    private void Awake()
    {
        _scoreLable.text = "0";
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt(GlobalConstants.SCORE_PREFS_KEY, _score);
        PlayerPrefs.Save();
    }
}
