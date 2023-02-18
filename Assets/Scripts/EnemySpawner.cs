using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<EnemyPathing> pathOptions = new List<EnemyPathing>();

    [SerializeField]
    private GameObject enemy;

    private SpawnerStates state = SpawnerStates.None;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("BeginWave");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy()
    {
        var newEnemy = Instantiate(enemy, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1), Quaternion.identity);

        var value = Random.Range(0, pathOptions.Count);

        newEnemy.GetComponent<Enemy>().Init(pathOptions[value]);
    }

    IEnumerator BeginWave() 
    {
        SpawnEnemy();
        yield return new WaitForSeconds(5);
        SpawnEnemy();
        yield return new WaitForSeconds(5);
        SpawnEnemy();
        yield return new WaitForSeconds(5);
        SpawnEnemy();

    }
}

public enum SpawnerStates
{
    Waiting,
    Spawning,
    None
}
