using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public float strength;
    private float cooldown = 2.0f;
    private float timer = 0f;
    public int killedMonsters = 0;
    // Update is called once per frame
    private void Start() {
        strength = gameObject.GetComponent<Character>().Strength.BaseValue;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if(Input.GetMouseButton(0))
        {
            animator.SetBool("Attacking", true);
            Attack();
        }
        else
        {
            animator.SetBool("Attacking", false);
        }
    }

    void Attack()
    {
        if(timer >= cooldown)
        {
            Debug.Log(timer);
            timer = 0;
            foreach(var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                if(Vector3.Distance(
                    GameObject.FindGameObjectWithTag("Player").transform.position,
                    enemy.transform.position) < 6)
                    {
                        Debug.Log(enemy.GetComponent<Enemy>().health);
                        Debug.Log("Strength: " + strength + " Enemy HP: " + enemy.GetComponent<Enemy>().health);
                        enemy.GetComponent<Health>().ModifyHealth(strength * (-1));
                        if(enemy.GetComponent<Enemy>().health <= 0)
                        {
                            Destroy(enemy);
                            killedMonsters++;
                        }
                    }
            }
        }
    }
}
