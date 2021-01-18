using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int hp=10;
    [SerializeField]
    private GameObject weapon=null;
    private Weapon w;
    private Job job;
    // job -> weapon.animator.setTrigger
    // job.doAttack(weapon)

    private int health=10;
    private int attackDamage=1;
    private int magicDamage=5;
    private int attackSpeed=50;
    private int armor=3;
    [SerializeField]
    private bool weaponTypeCheck=true;


    SpriteRenderer spriteRenderer;
    Animator anim;
    private void Awake()
    {
        job = new Magician();
        //job = new Knight();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        weapon = Instantiate(weapon,transform);
        weapon.transform.position = transform.position + new Vector3(0.129f, -0.218f);
        w = weapon.GetComponent<Weapon>();
        weaponTypeCheck = job.weaponCheck(w.Type);
    }

    private void Update()
    {
        doMovement();
        playerAttack();
    }

    private void doMovement()
    {
        // 간단한 이동
        float x = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(x, 0, 0) * Time.deltaTime * 3.0f;
        // 방향 전환
        if (Input.GetButton("Horizontal"))
        {
            anim.SetBool("isWalk", true);
            if(x*transform.localScale.x == -1.0)
            {
                transform.localScale = new Vector3(x, 1, 1);
            }
        }
        else
        {
            anim.SetBool("isWalk", false);
        }
    }

    private void playerAttack()
    {
        // 기본공격
        if (Input.GetKeyDown(KeyCode.A))
        {
            // 직업이 지원하는 무기와 맞으면 직업의 공격모션.
            // 아니라면 무기의 기본 공격 모션 사용
            if (weaponTypeCheck)
                job.doAttack(weapon);
            else
                w.doAttack();
        }
        // 스킬 1
        else if (Input.GetKeyDown(KeyCode.S))
        {
            job.doSkill1(weapon);
        }
        // 스킬 2
        else if (Input.GetKeyDown(KeyCode.D))
        {
            job.doSkill2(weapon);
        }
    }

    private void addStatus(int health, int ad, int md, int aspeed, int armor, bool weaponTypeCheck)
    {
        this.health += health;
        this.attackDamage += ad;
        this.magicDamage += md;
        this.armor += armor;
        // 상한치 임시로 100
        if(this.attackSpeed + aspeed > 100)
        {
            this.attackSpeed = 100;
        }

        // 무기 적성 갱신
        weaponTypeCheck = job.weaponCheck(w.Type);

        // 직업 변경 가능 여부 확인
        job.checkJobChange(health, ad, md, aspeed, armor);
    }
}
