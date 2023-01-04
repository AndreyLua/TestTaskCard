using UnityEngine;
using TMPro;

public class Title : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private TextMeshProUGUI _name;

    public TextMeshProUGUI Name => _name;
}
