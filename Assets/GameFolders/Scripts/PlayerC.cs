using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : MonoBehaviour
{
    public static PlayerC Instance;
    public Animator CharacterAnimator;
    public List<Transform> Barrels = new List<Transform>();
    public Transform ActiveBarrel;
    public GameObject Bullet;
    public float PlayerHealt = 100;
    public GunTypes GunType;

    bool _canFire=true;

    public enum GunTypes
    {
        Idle,
        Pistol,
        Rifle,
        HardGun
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CharacterAnimator.SetTrigger("Idle");
            GunType = GunTypes.Idle;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CharacterAnimator.SetTrigger("Pistol");
            GunType = GunTypes.Pistol;
            PassiveBarrels();
            ActiveBarrels(0);
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CharacterAnimator.SetTrigger("Rifle");
            GunType = GunTypes.Rifle;
            PassiveBarrels();
            ActiveBarrels(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            CharacterAnimator.SetTrigger("HardGun");
            GunType = GunTypes.HardGun;
            PassiveBarrels();
            ActiveBarrels(2);
        }

        if (Input.GetMouseButtonDown(0) && GunType != GunTypes.Idle && _canFire)
        {
            print("ates ediliyooorr");
            GameObject cloneBullet = Instantiate(Bullet, ActiveBarrel.position, Quaternion.identity);
            Rigidbody rbBullet = cloneBullet.GetComponent<Rigidbody>();
            rbBullet.AddForce(ActiveBarrel.forward * 2000, ForceMode.Acceleration);
            print("ates ediliyooorr 2");
            switch (GunType)   
            {
                case GunTypes.Idle:

                    break;
                case GunTypes.Pistol:
                    StartCoroutine(FireDurationDelay(1));
                    break;
                case GunTypes.Rifle:
                    StartCoroutine(FireDurationDelay(0.3f));
                    break;
                case GunTypes.HardGun:
                    StartCoroutine(FireDurationDelay(4));
                    break;
                default:
                    break;
            }
            _canFire = false;

        }
    }

    IEnumerator FireDurationDelay(float duration)
    {
        yield return new WaitForSeconds(duration);
        _canFire = true;
    }

    private void PassiveBarrels()
    {
        foreach (Transform item in Barrels)
        {
            item.gameObject.SetActive(false);
        }
    }
    private void ActiveBarrels(int barrelIndex)
    {
        Barrels[barrelIndex].gameObject.SetActive(true);
        ActiveBarrel = Barrels[barrelIndex];
    }

}
