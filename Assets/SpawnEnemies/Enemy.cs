using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent enemy;
    public GameObject player;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.transform.position);
    }
}
