using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;

public class Card : MonoBehaviour
{
    [SerializeField] private ParameterStorageView[] _storageViews;
    [SerializeField] private Title _title;
    [SerializeField] private DescriptionCard _description;
    [SerializeField] private CardArt _art;

    private Dictionary<ParametersType, ParameterStorageView> _parameterStorageViewInPairType;
    private Dictionary<ParametersType, ParameterStorageBase> _parameterStorageBaseInPairType;

    private AttackStorage _attackStorage;
    private HealthStorage _healthStorage;
    private ManaStorage _manaStorage;

    public event System.Action<Card> Destroyed;

    public AttackStorage AttackStorage => _attackStorage;
    public HealthStorage HealthStorage => _healthStorage;
    public ManaStorage ManaStorage => _manaStorage;

    public void SetParameters(CardParameters parameters)
    {
        _attackStorage.ChangeValue(parameters.Attack);
        _healthStorage.ChangeValue(parameters.Health);
        _manaStorage.ChangeValue(parameters.Mana);
    }

    public void SetParameter(ParametersType type, int value)
    {
        _parameterStorageBaseInPairType[type].ChangeValue(value);
        transform.SetSiblingIndex(100);
    }

    public void SetArt(Sprite sprite)
    {
        _art.Image.sprite = sprite;
    }

    private void Awake()
    {
        _parameterStorageBaseInPairType = new Dictionary<ParametersType, ParameterStorageBase>();

        _attackStorage = new AttackStorage(Random.Range(1, 9));
        _healthStorage = new HealthStorage(Random.Range(1, 9));
        _manaStorage = new ManaStorage(Random.Range(1, 9));

        _parameterStorageViewInPairType = _storageViews.ToDictionary(value => value.Type, value => value);

        _parameterStorageBaseInPairType.Add(_attackStorage.Type, _attackStorage);
        _parameterStorageBaseInPairType.Add(_healthStorage.Type, _healthStorage);
        _parameterStorageBaseInPairType.Add(_manaStorage.Type, _manaStorage);

        foreach (var parameterStorageView in _parameterStorageViewInPairType)
            _parameterStorageBaseInPairType[parameterStorageView.Key].ValueChanged += parameterStorageView.Value.UpdateTextValue;

        _healthStorage.Died += OnDied;
    }

    private void OnDied()
    {
        _healthStorage.Died -= OnDied;
        Destroy(gameObject);
        Destroyed?.Invoke(this);
    }
}