using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToDestroy : MonoBehaviour
{
    public delegate void ObjectDestroyed();
    public static event ObjectDestroyed OnObjectDestroyed;
    
    private void OnDestroy()
    {
        if (OnObjectDestroyed != null)
        {
            OnObjectDestroyed();
        }
    }



}
