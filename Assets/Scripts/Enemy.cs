using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2.0f;
    Player _player;
    Animator _anim;
    AudioSource _audiosource;
    [SerializeField]
    GameObject _laserPrefab;
    [SerializeField]
    float _fireRate = 0.5f;
    [SerializeField]
    float _canFire = -1;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _audiosource = GetComponent<AudioSource>();
        if (_player == null)
        {
            Debug.LogError("Player is null");
        }
        _anim = GetComponent<Animator>();
        if (_anim == null)
        {
            Debug.LogError("Anim is null");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        if(Time.time > _canFire)
        {
            _fireRate = Random.Range(4.5f, 7f);
            _canFire = Time.time * _fireRate;
            spawnLaserEnemy();
           
        }

    }
    void CalculateMovement()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -5f)
        {
            transform.position = new Vector3(Random.Range(-8f, 8f), 7, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
         {
            Player  player = other.transform.GetComponent<Player>();
         
            if (player != null)
            {
                player.Damage();
            }
            _anim.SetTrigger("OnEnemyDeath");
            speed = 0;
            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject,2.0f);
            _audiosource.Play();
        }

        if (other.tag == "Laser")
        {
            
            Destroy(other.gameObject);
            if (_player != null)
            {
                _player.Addtoscore(10);
            }
            _anim.SetTrigger("OnEnemyDeath");
            speed = 0f;
            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject,2.0f);
            _audiosource.Play();
        }
    }

    void spawnLaserEnemy()
    {
        //if (Input.GetKeyDown(KeyCode.Space) && Time.time > _rateofFire)


        

       
      
        
            Instantiate(_laserPrefab, transform.position , Quaternion.identity );
       

    }
}
