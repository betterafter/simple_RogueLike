using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private GameObject[] weaponsList;

    private GameObject weaponToGet;

    private int health;
    private int ad;
    private int md;
    private int aspeed;
    private int armor;

    private void Awake()
    {
        health = Random.Range(0, 50);
        ad = Random.Range(0, 50);
        md = Random.Range(0, 50);
        aspeed = Random.Range(0, 50);
        armor = Random.Range(0, 50);
        weaponToGet = Instantiate(weaponsList[Random.Range(0, weaponsList.Length)],transform.position+new Vector3(-0.2f,0.5f),Quaternion.identity);
        weaponToGet.transform.parent = gameObject.transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Health : " + health);
        Debug.Log("Attack Damage : " + ad);
        Debug.Log("Magic Damage : " + md);
        Debug.Log("Attack Speed : " + aspeed);
        Debug.Log("Armor : " + armor);

        collision.gameObject.GetComponent<PlayerController>().addStatus(health, ad, md, aspeed, armor, weaponToGet);
        Destroy(gameObject);
    }
}
