using UnityEngine;

public class CardDistributor : MonoBehaviour
{
    [SerializeField] private CardCreator _creator;
    [SerializeField] private CardHand _hand;
    private void Start()
    {
        CardParameters parameters = new CardParameters(5, 5, 5);
        for (int i=0; i<Random.Range(4,7); i++)
        {
            Card newCard = _creator.Create(parameters);
            _hand.Storage.Add(newCard);
        }
    }
}
