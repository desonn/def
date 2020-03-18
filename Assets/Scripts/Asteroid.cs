using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 4.0f;

    [SerializeField]
    GameObject _expoPrefab;
    SpawnManager _spawnManager;
    // Start is called before the first frame update
    void Start()

    {
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
         _spawnManager.StartSpawn();
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
      
        
    

    }
  ////  private void OnTriggerEnter2D(Collider2D other)
  //  {
  //      if (other.tag == "Laser")
  //      {

          
           
  //          {
  //              Instantiate(_expoPrefab, transform.position,  Quaternion.identity);
               
  //          }
            
  //          speed = 0f;
            
  //          Destroy(other.gameObject);
  //        //  _spawnManager.StartSpawn();
  //          Destroy(this.gameObject);
  //      }
  //  }
}

