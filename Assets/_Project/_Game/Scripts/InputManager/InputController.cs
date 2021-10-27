using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public event Action PressedConfirmed = delegate { };
    public event Action PressedCanceled = delegate { };
    public event Action PressedLeft = delegate { };
    public event Action PressedRight = delegate { };

    void DetectConfirm()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            PressedConfirmed?.Invoke();
    }

    void DetectCancel()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            PressedCanceled?.Invoke();
    }

    void DetectLeft()
    {
        if (Input.GetKeyDown(KeyCode.A))
            PressedLeft?.Invoke();
    }

    void DetectRight()
    {
        if (Input.GetKeyDown(KeyCode.D))
            PressedRight?.Invoke();
    }

    void Update()
    {
        DetectConfirm();
        DetectCancel();
        DetectRight();
        DetectLeft();
    }
}