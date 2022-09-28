using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    private TextMeshProUGUI textMesh;
    public float strength = 0;
    private float cooldown = 0.83f;
    private float timer = 0f;
    public int killedMonsters = 0;
    public TextMeshProUGUI tmp;
    // Update is called once per frame
    private void Start() {
        strength = gameObject.GetComponent<Character>().Strength.BaseValue + StatsUpgrading.strUpgrade;
    }
    void Update()
    {
        strength = gameObject.GetComponent<Character>().Strength.BaseValue + StatsUpgrading.strUpgrade;
        
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
            timer = 0;
            foreach(var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                if(Vector3.Distance(
                    GameObject.FindGameObjectWithTag("Player").transform.position,
                    enemy.transform.position) < 6)
                    {
                        enemy.GetComponent<Health>().ModifyHealth((strength) * (-1));
                        if(enemy.GetComponent<Health>().currentHealth <= 0)
                        {
                            killedMonsters++;
                            tmp.text = "Zabite Potwory: " + killedMonsters;
                            
                        }
                    }
            }
        }
    }
}
