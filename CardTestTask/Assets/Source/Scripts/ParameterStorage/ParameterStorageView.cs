using DG.Tweening;
using TMPro;
using UnityEngine;

public class ParameterStorageView : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private ParametersType _type;

    private float _value = 0;

    public ParametersType Type => _type;
    public Sprite Sprite => _sprite;

    public void UpdateTextValue(int endValue)
    {
        DOTween.To(() => _value, x => 
        { 
            _value = x; 
            _text.text = ((int)_value).ToString(); 
        }, 
        endValue, 2f);
    }
}