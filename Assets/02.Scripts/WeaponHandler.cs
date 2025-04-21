using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private GameObject weaponLogic;

    public void EnableWaeapon()
    {
        weaponLogic.SetActive(true);
    }


    public void DisableWaepon()
    {
        weaponLogic.SetActive(false);
    }
}
