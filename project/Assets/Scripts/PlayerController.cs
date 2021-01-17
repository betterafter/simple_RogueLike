using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int hp;
    private Weapon w;
    private Job job;
    private int health;
    private int attackDamage;
    private int magicDamage;
    private int attackSpeed;
    private int armor;
    private bool weaponTypeCheck;

    private void doMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(x, 0, 0) * Time.deltaTime * 3.0f;
    }

    private void playerAttack()
    {
        if(Input.GetKeyDown())
    }

    private void addStatus(int health, int ad, int md, int aspeed, int armor, bool weaponTypeCheck)
    {

    }




}
