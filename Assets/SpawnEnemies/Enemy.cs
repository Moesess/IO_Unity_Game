using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent enemy;
    private GameObject player;
    public float health;
    public float strength;
    public Animator animator;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        health = gameObject.GetComponent<Character>().HealthPoints.BaseValue;
        strength = gameObject.GetComponent<Character>().Strength.BaseValue;
    }
    
    void Start()
    {
        animator.SetBool("Attacking", false);
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.transform.position);
        if(Vector3.Distance(
        GameObject.FindGameObjectWithTag("Player").transform.position,
        gameObject.transform.position) < 4)
        {
            animator.SetBool("Attacking", true);
            //GameObject.FindGameObjectWithTag("Player").GetComponent<Character>().HealthPoints.AddModifier()
        }
        else
        {
            animator.SetBool("Attacking", false);
        }
    }
}
