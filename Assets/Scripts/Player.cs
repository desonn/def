using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour


{
    [SerializeField]
     float _speed = 3.5f;
    [SerializeField]
    int _speedMultiplier = 2;
    [SerializeField]
    GameObject _laserPrefab;
    [SerializeField]
    float _fireRate = 0.5f;
    [SerializeField]
    float _rateofFire = -1f;
    [SerializeField]
    int _lives = 3;
    SpawnManager _spawnManager;
    [SerializeField]
    int _score;
    UIManager _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();

    [SerializeField]
    GameObject _tripleshotPrefab;
    [SerializeField]
    GameObject _shieldPrefab;
    [SerializeField]
    GameObject _rightengine, _leftengine;
    [SerializeField]
    AudioClip _laser;
    [SerializeField]
    AudioSource _audioSource;
  


    bool _isTripleshotactive = false;
    bool _isSpeedboostactive = false;
    bool _isShieldsactive = false;
    // Start is called before the first frame update
    void Start()
    {
    
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _audioSource = GetComponent<AudioSource>();
        _rightengine.SetActive(false);
        _leftengine.SetActive(false);
        if (_spawnManager == null)
        {
            Debug.LogError("the spawn manager is null");
        }
        if (_uiManager == null)
        {
            Debug.LogError("the UI manager is null");
        }
        if (_audioSource == null)
        {
            Debug.LogError("the Audio source is null");
        }
        else
        {
            _audioSource.clip = _laser;
        }
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
        

        if ((Input.GetKeyDown(KeyCode.Space) ||CrossPlatformInputManager.GetButtonDown("Fire") && Time.time > _rateofFire))
        {
            spawnLaser();
        }
       
      
    }


    void playerMovement()
    {
        float horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal"); // GetAxis("Horizontal");
        float verticalInput = CrossPlatformInputManager.GetAxis("Vertical");// Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

       

        
        
            transform.Translate(direction * _speed * Time.deltaTime);
        
       
        

        if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y <= -3.8f)
        {
            transform.position = new Vector3(transform.position.x, -3.8f, 0);
        }
        if (transform.position.x > 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x < -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
    }

    void spawnLaser()
    {
        //if (Input.GetKeyDown(KeyCode.Space) && Time.time > _rateofFire)

       
            _rateofFire = Time.time + _fireRate;
        
        if (_isTripleshotactive == true)
        {
            Instantiate(_tripleshotPrefab, transform.position , Quaternion.identity);
        }
        else
             {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);
             }
        _audioSource.Play();
        
    }

    public void Damage()
    {
        if(_isShieldsactive== true)
        {
            _isShieldsactive = false;
            _shieldPrefab.SetActive(false);

            return;
        }
        _lives -- ;
        if (_lives == 2)
        {
            _rightengine.SetActive(true);
        }
       else if (_lives == 1)
        {
            _leftengine.SetActive(true);
        }
        _uiManager.UpdateLives(_lives);

        if(_lives < 1)
        
        {
            _spawnManager.OnPlayerDeath();
           
             Destroy(this.gameObject);

          
        }
    }
    public void Tripleshotactive()
    {
        _isTripleshotactive = true;
        StartCoroutine(Tripleshotpowerdownroutine());
    }
    IEnumerator Tripleshotpowerdownroutine()
    {
        yield return new WaitForSeconds(5.0f);
        _isTripleshotactive = false;
    }
    public void Speedboostactive()
    {
        _isSpeedboostactive = true;
        _speed *= _speedMultiplier;
        StartCoroutine(SpeedBoostpowerdownroutine());
    }
    IEnumerator SpeedBoostpowerdownroutine()
    {
        yield return new WaitForSeconds(5.0f);
        _isSpeedboostactive = false;
        _speed  /= _speedMultiplier;
    }
    public void ShieldsActive()
    {
        _isShieldsactive = true;
        _shieldPrefab.SetActive(true);
    }
    public void Addtoscore(int points)
    {
        _score += points;
        _uiManager.UpdateScore(_score);
    }
}

