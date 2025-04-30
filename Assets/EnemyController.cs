using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class EnemyController : MonoBehaviour
{
    GameObject player;
    public float speed = 4f;
    LevelManager lm;
    // Start is called before the first frame update

    public int maxHP = 10;
    private int currentHP;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        currentHP = maxHP;
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        if (currentHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        lm.AddPoints(1);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        transform.LookAt(player.transform);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerWeapon"))
        {
            currentHP -= 5; // ? sta³a wartoœæ obra¿eñ, mo¿esz tu zmieniæ na 1, 10 itd.

            if (currentHP <= 0)
            {
                lm.AddPoints(1);
                Destroy(gameObject);
            }
        }
    }
}
