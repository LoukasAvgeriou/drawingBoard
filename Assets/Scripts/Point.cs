using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public static bool pressed;
    public TouchDraw touchDraw;

    private void OnMouseDown()
    {
        pressed = true;
        TouchDraw.StartLine(this.transform.position);
    }

    private void OnMouseEnter()
    {
        if (pressed)
        {
            TouchDraw.UpdateLine(this.transform.position);
        }
    }

    private void OnMouseUp()
    {
        if (pressed)
        {
            touchDraw.FinishLine(this.transform.position);
            pressed = false;
        }
    }
}
