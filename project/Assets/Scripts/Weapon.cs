using UnityEngine;

public enum WeaponTypes
{ 
    Sword,
    Blunt,
    Staff
}


public abstract class Weapon : MonoBehaviour
{
    protected WeaponTypes type;
    protected float power;

    public abstract void doAttack();
}
