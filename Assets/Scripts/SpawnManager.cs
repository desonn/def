using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject _enemyPrefab;
    [SerializeField]
    GameObject _enemyContainer;
    [SerializeField]
    GameObject[] _powerups ;
   
    bool _stopSpawning = false;
    // Start is called before the first frame update
    void Start()
    {
        StartSpawn();
    }
    public void StartSpawn()
    {
        StartCoroutine(SpawnRoutine());
        StartCoroutine(SpawnPowerupRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(15);
        while (_stopSpawning == false)

        {
            Vector3 postoSpawn = new Vector3(Random.Range(8f, -8f), 7, 0);
       GameObject newEnemy = Instantiate(_enemyPrefab,postoSpawn,Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(10);
        }
       
    
    }
    IEnumerator SpawnPowerupRoutine()
    {
        yield return new WaitForSeconds(3);
        while (_stopSpawning == false)

        {
            Vector3 postoSpawn = new Vector3(Random.Range(8f, -8f), 7, 0);
            int randomPowerup = Random.Range(0, 3);
            GameObject newTripleshot = Instantiate(_powerups[randomPowerup], postoSpawn, Quaternion.identity);
          //  _powerup.transform.parent = _powerupContainer.transform;
            yield return new WaitForSeconds(Random.Range(10,15));
        }


    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
