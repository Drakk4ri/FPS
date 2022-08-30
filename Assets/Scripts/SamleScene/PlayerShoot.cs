using System;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public static Action OnShootInput;
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            OnShootInput?.Invoke();
        }
    }
}
