using UnityEngine;

public abstract class Job : MonoBehaviour
{
    protected string jobName;
    public abstract void doAttack();
    public abstract void doSkill1(bool typeCheck);
    public abstract void doSkill2(bool typeCheck);
    public abstract Job checkJobChange(int health, int ad, int md, int aspeed, int armor);
    public abstract bool weaponCheck(WeaponTypes weapon);
}
