using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject[] weakEnemy;
    [SerializeField]
    public GameObject[] strongEnemy;
    // Start is called before the first frame update

    [SerializeField]
    private float weakEnemyInterval;
    [SerializeField]
    private float strongEnemyInterval;
    [SerializeField]

    void Start()
    {
       StartCoroutine(SpawnEnemy(weakEnemyInterval,weakEnemy[Random.Range(0,5)])); 
       StartCoroutine(SpawnEnemy(strongEnemyInterval,strongEnemy[Random.Range(0,1)]));
       StartCoroutine(IncreaseSpawnIntensity());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(gameObject.transform.position.x ,2,gameObject.transform.position.z),Quaternion.identity);
        StartCoroutine(SpawnEnemy(interval,enemy));
    }
    private IEnumerator IncreaseSpawnIntensity()
    {
        yield return new WaitForSeconds(20);
        weakEnemyInterval--;
        strongEnemyInterval--;
        StartCoroutine(IncreaseSpawnIntensity());
    }
}
