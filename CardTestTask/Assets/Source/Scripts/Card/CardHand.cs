using DG.Tweening;
using System;
using UnityEngine;

public class CardHand : MonoBehaviour
{
    [SerializeField] private int _maxNumberCards;
    [SerializeField] private float _handRadius;
    [SerializeField] private float _handLength;
    [SerializeField] private float _handSector;

    private CardStorage _storage;

    private float _sectorAngle => (_handSector * 2) / (_storage.Cards.Count+1);
    public CardStorage Storage => _storage;

    public void ChangeCardParameter(int numberCard, ParametersType type, int valueParameter)
    {
        if (numberCard < 0 || numberCard >= _storage.Cards.Count)
            throw new Exception("The card number goes beyond the limits of the storage");
    
        _storage.Cards[numberCard].SetParameter(type, valueParameter);
    }

    private void Awake()
    {
        _storage = new CardStorage(_maxNumberCards);
        _storage.Changed += OnStorageCardChanged;
    }

    private void OnStorageCardChanged()
    {
        float angle = -_handSector;
        foreach (Card card in _storage.Cards)
        {
            angle += _sectorAngle;
            Vector3 position = Camera.main.WorldToScreenPoint(Quaternion.Euler(0, 0, angle) * Vector3.up * _handRadius);
            position.y /= _handRadius / _handLength;
            card.transform.DOMove(position,2f);
            Vector3 offset = Camera.main.WorldToScreenPoint(new Vector3(0,_handRadius));
            card.transform.rotation = Quaternion.Euler(0, 0, -Mathf.Atan2(transform.position.x- position.x, 
            transform.position.y- position.y - offset.y) * Mathf.Rad2Deg + 180);
        }
    }

}
