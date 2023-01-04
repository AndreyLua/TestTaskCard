using UnityEngine;

public class CardCreator : MonoBehaviour
{
    [SerializeField] private Card _cardPrefab;
    [SerializeField] private Transform _gameScreen;
    [SerializeField] private CardSpriteDownloader cardSpriteDownloader;

    public Card Create(CardParameters parameters)
    {
        Card newCard = Instantiate<Card>(_cardPrefab, new Vector3(0,0,0), Quaternion.identity);
        StartCoroutine(cardSpriteDownloader.LoadSprite(newCard.SetArt));
        newCard.SetParameters(parameters);
        newCard.transform.SetParent(_gameScreen, false);
        return newCard;
    }
}