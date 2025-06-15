using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class CastingBar : MonoBehaviour
{
    [SerializeField] private SpellVampirism _spellVampirism;
    [SerializeField] private GameObject _backGround;
    [SerializeField] private GameObject _fillArea;

    private Slider _slider;

    protected void Awake()
    {
        _slider = GetComponent<Slider>();
        _backGround.SetActive(false);
        _fillArea.SetActive(false);
    }

    private void OnEnable()
    {
        _spellVampirism.SpellStarted += OnSpellStarted;
        _spellVampirism.TimeChanged += OnTimeChanged;
        _spellVampirism.CooldownEnded += OnCooldownEnded;
    }

    private void OnDisable()
    {
        _spellVampirism.SpellStarted -= OnSpellStarted;
        _spellVampirism.TimeChanged -= OnTimeChanged;
        _spellVampirism.CooldownEnded -= OnCooldownEnded;
    }

    private void OnSpellStarted()
    {
        _backGround.SetActive(true);
        _fillArea.SetActive(true);
    }

    private void OnTimeChanged(float time, float maxTime)
    {
        _slider.value = time / maxTime;
    }

    private void OnCooldownEnded()
    {
        _backGround.SetActive(false);
        _fillArea.SetActive(false);
    }
}