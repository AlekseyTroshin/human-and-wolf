using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] private Image _health;
    [SerializeField] private float _delta;

    private float _healthValue;
    private float _currentHealth;
    private Player _player;

    private void Start()
    {
        _player = FindObjectsByType<Player>(FindObjectsSortMode.None)[0];
        _healthValue = _player.Health.CurrentHealth / 100f;
    }

    private void Update()
    {
        _currentHealth = _player.Health.CurrentHealth / 100f;

        if (_currentHealth > _healthValue)
            _healthValue += _delta;
        if (_currentHealth < _healthValue)
            _healthValue -= _delta;
        if (Math.Abs(_currentHealth - _healthValue) < _delta)
            _healthValue = _currentHealth;

        _health.fillAmount = _healthValue;

    }

}
