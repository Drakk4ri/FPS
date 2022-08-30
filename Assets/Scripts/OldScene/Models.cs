using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class Models
{

    #region Player
    [Serializable]
    public class PlayerSettingsModel
    {
        
        [Header("View Settings")]
        public float ViewXSensitivity;
        public float ViewYSensitivity;

        public bool ViewXInverted;
        public bool ViewYInverted;



        [Header("Movement")]
        public float walkingForawrdSpeed;
        public float walkingBackwardSpeed;
        public float walskingStrafeSpreed;
    }

    #endregion


    #region Weapons

    public enum WeaponFireType
    {

    }

    #endregion
}
