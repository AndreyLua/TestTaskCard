using System;
using System.Collections.Generic;

public class CardStorage
{
    private List<Card> _cards;
    private int _maxNumberCards;

    public event Action Changed;
    public  List<Card> Cards => _cards;
    public int MaxNumberCards => _maxNumberCards;

    public CardStorage(int maxNumberCards)
    {
        _maxNumberCards = maxNumberCards;
        _cards = new List<Card>();
    }

    public void Add(Card card)
    {
        if (_maxNumberCards <= _cards.Count)
            throw new Exception("CardStorage can't store more than the maximum number cards");
        _cards.Add(card);
        card.Destroyed += Delete;
        Changed?.Invoke();
    }

    public void Delete(Card card)
    {
        card.Destroyed -= Delete;
        _cards.Remove(card);
        Changed?.Invoke();
    }
}