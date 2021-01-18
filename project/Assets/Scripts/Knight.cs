using UnityEngine;

public class Knight : Job
{
    public Knight()
    {
        this.jobName = "Knight";
    }
    public override void doAttack(GameObject weapon)
    {
        // 기사 공격 찌르기
        Weapon w = weapon.GetComponent<Weapon>();
        w.Anim.SetTrigger("isKnightAttack");
    }
    public override void doSkill1(GameObject weapon)
    {
        // 미구현
        Debug.Log("기사 스킬1");
    }
    public override void doSkill2(GameObject weapon)
    {
        // 미구현
        Debug.Log("기사 스킬2");
    }
    public override Job checkJobChange(int health, int ad, int md, int aspeed, int armor)
    {
        Debug.Log("기사로 바꿀 수 있는지");
        return null;
    }
    public override bool weaponCheck(WeaponTypes weapon)
    {
        return weapon == WeaponTypes.Sword;
    }
}
