using UnityEngine;

public class CardChanger : MonoBehaviour
{
    [SerializeField] private ChangeCardButton _button;
    [SerializeField] private CardHand _hand;

    private ParametersType[] _parametersTypes;

    private int _numberCard = 0;

    private void Awake()
    {
        _parametersTypes = System.Enum.GetValues(typeof(ParametersType)) as ParametersType[];
        _button.ChangeCard += OnChangeCard;
    }

    private void OnChangeCard()
    {
        if (_hand.Storage.Cards.Count > 0)
        {
            _hand.ChangeCardParameter(_numberCard, _parametersTypes[Random.Range(0, _parametersTypes.Length)],
                Random.Range(-2, 10));
            _numberCard++;
            if (_numberCard >= _hand.Storage.Cards.Count)
                _numberCard = 0;
        }
    }

}
