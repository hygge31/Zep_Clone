using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Weapon weapon;


    public void RotateArm(Vector2 dir)
    {
        float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        weapon.GetComponent<SpriteRenderer>().flipY = Mathf.Abs(rotZ) > 90;
        weapon.GetComponent<SpriteRenderer>().flipX = weapon.GetComponent<SpriteRenderer>().flipY;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
