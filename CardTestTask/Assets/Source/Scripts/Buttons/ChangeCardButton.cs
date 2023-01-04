using System;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCardButton : MonoBehaviour
{
    private Button _changeCardButton;
    public event Action ChangeCard;
  
    private void Awake()
    {
        _changeCardButton = gameObject.GetComponent<Button>();
        _changeCardButton.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        ChangeCard?.Invoke();
    }
}
