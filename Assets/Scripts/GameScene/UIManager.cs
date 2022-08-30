using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject[] weaponIndicator = new GameObject[3];

    private void Start()
    {
        for (int i = 0; i < weaponIndicator.Length; i++)
        {
            weaponIndicator[i].SetActive(false);
        }
    }

    public void setWeapon(int e)
    {
        for(int i = 0; i < weaponIndicator.Length; i++)
        {
            weaponIndicator[i].SetActive(false);
        }
        for (int i = 0; i < weaponIndicator.Length; i++)
        {
            if (i == e) weaponIndicator[i].SetActive(true);
        }
    }
}
