using UnityEngine;

public class Magician : Job
{
    private bool denyElementalist = false;
    private bool denyPriest = false;

    public Magician()
    {
        jobName = "Magician";
    }

    public override void doAttack(GameObject weapon)
    {
        // 구 소환
        Weapon w = weapon.GetComponent<Weapon>();
        w.Anim.SetTrigger("isFireBall");
        GameObject f = Instantiate((GameObject)Resources.Load("Ball"),new Vector3(0.842f, 0.061f, -1f), Quaternion.identity);
        f.GetComponent<FireBall>().setDirection(new Vector3(1,0,0));
    }

    public override void doSkill1(GameObject weapon)
    {
        // 미구현 상태
    }

    public override void doSkill2(GameObject weapon)
    {
        // 미구현 상태
    }

    public override Job checkJobChange(int health, int ad, int md, int aspeed, int armor)
    {
        if(denyPriest == false && armor > 100)
        {
            Debug.Log("성직자로 전직이 가능합니다.");
            denyPriest = true;
            // 원래는 UI로 띄워서 확인창 같은거 처리.
            // 확인을 누르던 거절을 누르던 다시 이 메세지가 출력되지않도록.
            // return new Priest();
            return null;
        }
        if(denyElementalist == false && md > 200)
        {
            Debug.Log("원소술사로 전직이 가능합니다.");
            denyElementalist = true;
            // return new Elementalist();
            return null;
        }

        // 실제 구현단계에서는 반환값을 그대로 직업에 적용시켜서 사용
        return null;
    }

    public override bool weaponCheck(WeaponTypes weapon)
    {
        // 마법사는 지팡이만 지원한다.
        return weapon == WeaponTypes.Staff;
    }
}
