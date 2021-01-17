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
    public WeaponTypes Type
    {
        get
        {
            return type;
        }
        set
        {
            type = value;
        }
    }
    protected float power;

    public abstract void doAttack();
}
