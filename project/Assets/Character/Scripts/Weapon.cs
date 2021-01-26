using UnityEngine;

public enum WeaponTypes
{ 
    Sword,
    Blunt,
    Staff
}


public abstract class Weapon : MonoBehaviour
{
    protected Animator anim;
    public Animator Anim
    {
        get
        {
            return anim;
        }
    }


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

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public abstract void doAttack();
}
