using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            animator.SetBool("Attacking", true);
            foreach(var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                if(Vector3.Distance(
                    GameObject.FindGameObjectWithTag("Player").transform.position,
                    enemy.transform.position) < 3)
                    {
                        Destroy(enemy);
                    }
            }

        }
        else
        {
            animator.SetBool("Attacking", false);
        }
    }
}
