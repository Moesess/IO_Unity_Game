using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject weakEnemy;
    [SerializeField]
    private GameObject strongEnemy;
    // Start is called before the first frame update

    [SerializeField]
    private float weakEnemyInterval = 3.5f;
    [SerializeField]
    private float strongEnemyInterval = 6.5f;

    void Start()
    {
       StartCoroutine(spawnEnemy(weakEnemyInterval,weakEnemy)); 
       StartCoroutine(spawnEnemy(strongEnemyInterval,strongEnemy));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(65,75),2,Random.Range(44,54)),Quaternion.identity);
        StartCoroutine(spawnEnemy(interval,enemy));
    }
}
