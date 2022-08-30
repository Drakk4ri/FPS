using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName="Gun", menuName = "Weapon/Gun")]


public class GunData : ScriptableObject
{

    
    
    public string gunName;

    public float damage;
    public float maxDistance;

}
