using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent enemy;
    private GameObject player;
    public float strength;
    public Animator animator;
    private float cooldown = 2.0f;
    private float timer = 0f;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        strength = gameObject.GetComponent<Character>().Strength.BaseValue;
    }
    
    void Start()
    {
        animator.SetBool("Attacking", false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        enemy.SetDestination(player.transform.position);
        if(Vector3.Distance(
        GameObject.FindGameObjectWithTag("Player").transform.position,
        gameObject.transform.position) < 4 && timer >= cooldown)
        {
            timer = 0;
            animator.SetBool("Attacking", true);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().ModifyHealth(strength * (-1));
            animator.SetBool("Attacking", false);
        }
    }
}
