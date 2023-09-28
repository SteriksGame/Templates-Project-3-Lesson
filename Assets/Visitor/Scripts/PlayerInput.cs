using System;
using UnityEngine;

public class PlayerInput
{
    public event Action OnPressedSpace;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            OnPressedSpace?.Invoke();
    }
}
