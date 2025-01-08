using System;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class Clicker : MonoBehaviour
{
    public event Action OnClick;

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        Touch.onFingerDown += Click;
    }

    private void OnDisable()
    {
        Touch.onFingerDown -= Click;
        EnhancedTouchSupport.Disable();
    }

    private void Click(Finger finger)
    {
        if (Touch.activeFingers[0].currentTouch.began)
        {
            OnClick?.Invoke();
            Debug.Log("Clicked");
        }
    }

}
