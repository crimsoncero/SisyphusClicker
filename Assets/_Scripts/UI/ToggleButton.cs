using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Button))]
public class ToggleButton : MonoBehaviour
{
    [SerializeField] private Sprite _enabledSprite;
    [SerializeField] private Sprite _disabledSprite;
    [SerializeField] private Button _button;

    public void Toggle(bool state)
    {
        if (state)
        {
            _button.image.sprite = _enabledSprite;
        }
        else
        {
            _button.image.sprite = _disabledSprite;
        }
    }
}
