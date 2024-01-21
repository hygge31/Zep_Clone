using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Weapon : MonoBehaviour
{
    public string weaponName;
    public WeaponType weaponType;
    public float weaponAttackDamage;
    public float weaponAttackSpeed;

    public GameObject projectileHolder;
    public Projectile projectile;
    



    public void  Instantiate_Projectile(Vector2 _dir)
    {
        Projectile projectile = Instantiate(this.projectile, projectileHolder.transform.position, Quaternion.identity);
        Destroy(projectile.gameObject, 2f);
        projectile.dir = _dir;
    }

}
