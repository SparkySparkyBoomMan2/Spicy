using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    public abstract class Weapon
    {
        public GameObject WeaponHolder;
        public abstract void addWeapon();

        protected virtual void Awake()
        {
            GameObject PlayerVariant = GameObject.Find("Player Variant");
            WeaponHolder = PlayerVariant.transform.Find("(TEST)WeaponHolder").gameObject;
            
            if (WeaponHolder == null)
                Debug.Log("null");
            //else
                //Debug.Log("MIRAACLE");
        }
    }

    public class add_handCannon : Weapon
    {
        public override void addWeapon()
        {
            base.Awake();
            
            var prefab = Resources.Load<GameObject>("Alex/handCannon");
            var gun = Instantiate(prefab) as GameObject;
            gun.transform.parent = WeaponHolder.transform;
            

            gun.transform.localPosition = new Vector3(1.638f, -0.96f, 57.17585f);
            gun.transform.localScale = new Vector3(2.047193f, 2.117647f, 3.344665f);
        }
    }
    public class add_submGun : Weapon
    {
        public override void addWeapon()
        {
            base.Awake();
            
            var prefab = Resources.Load<GameObject>("Alex/mac10Gun");
            GameObject gun = Instantiate(prefab) as GameObject;

            gun.transform.parent = WeaponHolder.transform;

            gun.transform.localPosition = new Vector3(1.72f, -0.94f, 124.7404f);
            gun.transform.localScale = new Vector3(2.047193f, 2.117647f, 3.344665f);
        }
    }
    public class add_hotLauncher : Weapon
    {
        public override void addWeapon()
        {
            base.Awake();
            
            var prefab = Resources.Load<GameObject>("Alex/hotLauncher");
            var gun = Instantiate(prefab) as GameObject;
            gun.transform.parent = WeaponHolder.transform;

            gun.transform.localPosition = new Vector3(1.72f, -0.94f, 124.7404f);
            gun.transform.localScale = new Vector3(0.3811741f, 0.3505865f, 4.142298f);
        }
    }
    public class add_shotGun : Weapon
    {
        public override void addWeapon()
        {
            base.Awake();
            
            var prefab = Resources.Load<GameObject>("Alex/shotGun");
            var gun = Instantiate(prefab) as GameObject;
            gun.transform.parent = WeaponHolder.transform;

            gun.transform.localPosition = new Vector3(1.72f, -0.94f, 124.7404f);
            gun.transform.localScale = new Vector3(2.047193f, 2.117647f, 3.344665f);
        }
    }
    public class add_handGun : Weapon
    {
        public override void addWeapon()
        {
            base.Awake();
            
            var prefab = Resources.Load<GameObject>("Alex/handgun");
            var gun = Instantiate(prefab) as GameObject;
            gun.transform.parent = WeaponHolder.transform;

            gun.transform.localPosition = new Vector3(1.72f, -0.94f, 124.7404f);
            gun.transform.localScale = new Vector3(2.047193f, 2.117647f, 3.344665f);
        }
    }
    public class add_machineGun : Weapon
    {
        public override void addWeapon()
        {
            base.Awake();
            
            var prefab = Resources.Load<GameObject>("Alex/machineGun");
            var gun = Instantiate(prefab) as GameObject;
            gun.transform.parent = WeaponHolder.transform;

            gun.transform.localPosition = new Vector3(1.72f, -0.94f, 124.7404f);
            gun.transform.localScale = new Vector3(0.3720945f, 0.3849f, 0.6079206f);
        }
    }

    void OnEnable()
    {
        //Debug.Log("Im enabled");
        GameManager gameManager = FindObjectOfType<GameManager>();

        int playerLives = -1;
        if (gameManager != null)
        {
            playerLives = gameManager.lives;
        }

        Debug.Log("lives -> "+ playerLives);

        Weapon gun = null;
        
        for (int i = 1; i < 6; i++)
        {
            gun = makeWeapon(i);
            gun.addWeapon();
        }

        //Commented out for now until can work out the bugs with david
        /*
        if (playerLives == 3)
        {
            for (int i = 1; i < 3; i++)
            {
                gun = makeWeapon(i);
                gun.addWeapon();
            }
        
        }
        else if (playerLives == 2)
        {
            for (int i = 3; i < 5; i++)
            {
                gun = makeWeapon(i);
                gun.addWeapon();
            }
        }
        else if (playerLives == 1)
        {
            for (int i = 5; i < 6; i++)
            {
                gun = makeWeapon(i);
                gun.addWeapon();
            }
        }*/
    }


    public Weapon makeWeapon(int weaponIndex)
    {
        //Weapon newWeapon = null;

        switch(weaponIndex)
        {
            //case 0:
                //return new add_handGun();
                //break;
            case 1:
                //Debug.Log("WE HERE");
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
                return new add_handCannon();
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
