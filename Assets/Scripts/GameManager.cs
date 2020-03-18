using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    bool _isgameover;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)|| CrossPlatformInputManager.GetButtonDown("Fire") && _isgameover ==true)
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            {
            Application.Quit();
        } 
    }
    public void GameOver()
    {
        _isgameover = true;
    }
}