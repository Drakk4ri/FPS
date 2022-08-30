using UnityEngine;

public class WeaponController : MonoBehaviour
{

    [Header("References")]
    public UIManager uiManager;

    [Header("Shooting")]
    [HideInInspector] public bool isShooting;
    public Gun[] activeGun = new Gun [3];

    [Header("Changing guns")]
    public int weaponIndicator;
    public GameObject[] weapons = new GameObject[3];
 

    private void Start()
    {
        uiManager = GameObject.FindGameObjectWithTag("UISystem").GetComponent<UIManager>();
        uiManager.setWeapon(0);

        switchWeapons(0);
    }

    public void CalculateShoooting()
    {
        activeGun[weaponIndicator].shoot();

    }

    public void switchWeapons(int index)
    {
        for(int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }
        weapons[index].SetActive(true);
        uiManager.setWeapon(index);
        weaponIndicator = index;
    }

}
