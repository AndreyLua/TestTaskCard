using UnityEngine;
using TMPro;

public class DescriptionCard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    public TextMeshProUGUI Text => _text;
}