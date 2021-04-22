using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    
    public abstract class Weapon
    {
        void onStart()
        {
            WeaponHolder = GameObject.Find("WeaponHolder");
        }
        public GameObject WeaponHolder;
        public abstract void addWeapon();
    }

    public class add_handCannon : Weapon
    {
        public override void addWeapon()
        {
            var prefab = Resources.Load<GameObject>("Alex/handCannon");
            var gun = Instantiate(prefab) as GameObject;
            gun.transform.parent = WeaponHolder.transform;
            //Add weapon to WeaponHolder???
        }
    }
    public class add_submGun : Weapon
    {
        public override void addWeapon()
        {
            var prefab = Resources.Load<GameObject>("Alex/mac10Gun");
            var gun = Instantiate(prefab) as GameObject;
            gun.transform.parent = WeaponHolder.transform;
            //Add weapon to WeaponHolder???
        }
    }
    public class add_hotLauncher : Weapon
    {
        public override void addWeapon()
        {
            var prefab = Resources.Load<GameObject>("Alex/hotLauncher");
            var gun = Instantiate(prefab) as GameObject;
            gun.transform.parent = WeaponHolder.transform;
            //Add weapon to WeaponHolder???
        }
    }
    public class add_shotGun : Weapon
    {
        public override void addWeapon()
        {
            var prefab = Resources.Load<GameObject>("Alex/shotGun");
            var gun = Instantiate(prefab) as GameObject;
            gun.transform.parent = WeaponHolder.transform;
            //Add weapon to WeaponHolder???
        }
    }
    public class add_handGun : Weapon
    {
        public override void addWeapon()
        {
            var prefab = Resources.Load<GameObject>("Alex/handgun");
            var gun = Instantiate(prefab) as GameObject;
            gun.transform.parent = WeaponHolder.transform;
            //Add weapon to WeaponHolder???
        }
    }
    public class add_machineGun : Weapon
    {
        public override void addWeapon()
        {
            var prefab = Resources.Load<GameObject>("Alex/machineGun");
            var gun = Instantiate(prefab) as GameObject;
            gun.transform.parent = WeaponHolder.transform;
            //Add weapon to WeaponHolder???
        }
    }


    public Weapon makeWeapon(int weaponIndex)
    {
        //Weapon newWeapon = null;

        switch(weaponIndex)
        {
            case 0:
                return new add_handCannon();
                //break;
            case 1:
                return new add_submGun();
                //break;
            case 2:
                return new add_hotLauncher();
                //return new GunWeapon();
                //break; 
            case 3:
                return new add_shotGun();
                //return new GunWeapon();
                //break; 
            case 4:
                return new add_handGun();
                //return new GunWeapon();
                //break; 
            case 5:
                return new add_machineGun();
                //return new GunWeapon();
                //break; 
            default:
                return null;
                //break;     
        }
        //return null;
        //return Weapon;
    }
}
