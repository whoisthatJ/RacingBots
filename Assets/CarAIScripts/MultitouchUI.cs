using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityStandardAssets.Vehicles.Car;

public class MultitouchUI : MonoBehaviour {
    public RectTransform accelerateBtn;
    public RectTransform breakBtn;
    public RectTransform leftBtn;
    public RectTransform rightBtn;
    public CarUserControl userControl;

    void Update() {
#if !MOBILE_INPUT
        return;
#endif
        bool isVertical = false;
        for (int i = 0; i < Input.touchCount; i++) {
            Touch touch = Input.GetTouch(i);
            if (IsTouchOverButton(accelerateBtn, touch)) {
                userControl.Accelerate();
                isVertical = true;
            }
            if (IsTouchOverButton(breakBtn, touch)) {
                userControl.Break();
                isVertical = true;
            }            
        }
        if(! isVertical ) {
            userControl.ResetAcceleration();
        }
        bool isHorizontal = false;
        for (int i = 0; i < Input.touchCount; i++) {
            Touch touch = Input.GetTouch(i);
            if (IsTouchOverButton(leftBtn, touch)) {
                userControl.Left();
                isHorizontal = true;
            }
            else if (IsTouchOverButton(rightBtn, touch)) {
                userControl.Right();
                isHorizontal = true;
            };
        }
        if(! isHorizontal ) {
            userControl.ResetSteer();
        }
    }

    private bool IsTouchOverButton(RectTransform buttonRect, Touch touch) {
        Vector2 localPoint;
        // Convert the touch position into the local point of the button
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            buttonRect,
            touch.position,
            null,
            out localPoint
        );

        // Check if the touch is within the bounds of the button's RectTransform
        return buttonRect.rect.Contains(localPoint);
    }
}

