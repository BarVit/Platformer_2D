using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SmoothHealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Health _health;
    [SerializeField] private float _smoothlyChangingTime = 1f;

    private Coroutine _healthChanger;

    private void Start()
    {
        _healthBar.value = _health.Value;
    }

    private void OnEnable()
    {
        _health.Changed += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.Changed -= OnHealthChanged;
    }

    private void OnHealthChanged(int health)
    {
        if(_healthChanger != null)
            StopCoroutine(_healthChanger);

        _healthChanger = StartCoroutine(SmoothlyHealthChange(_healthBar.value, health));
    }

    private IEnumerator SmoothlyHealthChange(float startHealth, float targetHealth)
    {
        float elapsedTime = 0f;
        float healthDiaposone = Mathf.Abs(targetHealth - startHealth);
        float intermediateHealth;
        float deltaHealth;

        while (elapsedTime < _smoothlyChangingTime)
        {
            elapsedTime += Time.deltaTime;
            deltaHealth = Time.deltaTime * healthDiaposone / _smoothlyChangingTime;

            if (targetHealth > _healthBar.value)
                intermediateHealth = startHealth + elapsedTime * healthDiaposone / _smoothlyChangingTime;
            else
                intermediateHealth = startHealth - elapsedTime * healthDiaposone / _smoothlyChangingTime;

            _healthBar.value = Mathf.MoveTowards(_healthBar.value, intermediateHealth, deltaHealth);

            yield return null;
        }
    }
}