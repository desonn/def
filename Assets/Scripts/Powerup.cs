using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    float _speed = 3.0f;
    [SerializeField]// 0 = tripleshot, 1= speed, 2 = shield
    int _powerupID;
    [SerializeField]
    AudioClip _clip;
   
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -5f)
        {
            Destroy(this.gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            AudioSource.PlayClipAtPoint(_clip, transform.position);
            if (player != null)
            {
                switch (_powerupID)
                {
                    case 0:
                        player.Tripleshotactive();
                        break;
                    case 1:
                        player.Speedboostactive();
                        break;
                    case 2:
                        player.ShieldsActive();
                        break;
                    default:
                        Debug.Log("default");
                        break;
                }
            }
            Destroy(this.gameObject);

        }
   



    }
}
