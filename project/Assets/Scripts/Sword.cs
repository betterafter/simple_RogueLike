using UnityEngine;

public class Sword : Weapon
{
    public Sword()
    {
        this.Type = WeaponTypes.Sword;
        this.power = 10;
    }

    public override void doAttack()
    {
        anim.SetTrigger("isNormalAttack");
        //Debug.Log("검 기본 공격");
    }

}
