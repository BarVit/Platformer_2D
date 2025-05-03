using UnityEngine;
using System.Collections;

public class SmoothHealthBar : HealthBar
{
    [SerializeField] private float _smoothlyChangingTime = 1f;

    private Coroutine _healthChanger;

    public override void OnHealthChanged(int health)
    {
        if(_healthChanger != null)
            StopCoroutine(_healthChanger);

        _healthChanger = StartCoroutine(SmoothlyHealthChange(HealthBarSlider.value, health));
    }

    private IEnumerator SmoothlyHealthChange(float startHealth, float targetHealth)
    {
        float elapsedTime = 0f;

        targetHealth /= Health.MaxValue;

        while (elapsedTime < _smoothlyChangingTime)
        {
            elapsedTime += Time.deltaTime;
            HealthBarSlider.value = Mathf.Lerp(startHealth, targetHealth, elapsedTime);

            yield return null;
        }
    }
}