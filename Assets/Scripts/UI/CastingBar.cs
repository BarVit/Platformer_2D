using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class CastingBar : MonoBehaviour
{
    [SerializeField] private SpellVampirism _spellVampirism;
    [SerializeField] private float _castTime;

    private Slider _slider;

    protected void Awake()
    {
        _slider = GetComponent<Slider>();
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _spellVampirism.SpellStarted += OnSpellStarted;
        _spellVampirism.TimeChanged += OnTimeChanged;
        _spellVampirism.CooldownEnded += OnCooldownEnded;
    }

    private void OnDisable()
    {
        _spellVampirism.SpellStarted += OnSpellStarted;
        _spellVampirism.TimeChanged -= OnTimeChanged;
        _spellVampirism.CooldownEnded -= OnCooldownEnded;
    }

    private void OnSpellStarted()
    {
        gameObject.SetActive(true);
    }

    private void OnTimeChanged(float time, float maxTime)
    {
        _slider.value = time / maxTime;
    }

    private void OnCooldownEnded()
    {
        gameObject.SetActive(false);
    }
}