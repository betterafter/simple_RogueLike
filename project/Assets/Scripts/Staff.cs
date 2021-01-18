using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : Weapon
{
    public Staff()
    {
        this.Type = WeaponTypes.Staff;
    }
    public override void doAttack()
    {
        anim.SetTrigger("isNormalAttack");
    }
}
