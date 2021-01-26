using UnityEngine;

public abstract class Job : MonoBehaviour
{
    protected string jobName;
    public abstract void doAttack(GameObject weapon);
    public abstract void doSkill1(GameObject weapon);
    public abstract void doSkill2(GameObject weapon);
    public abstract Job checkJobChange(int health, int ad, int md, int aspeed, int armor);
    public abstract bool weaponCheck(WeaponTypes weapon);
}