using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField]
    Text _scoreText;
    [SerializeField]
    Sprite[] _livesSprites;
    [SerializeField]
    Image _livesimg;

    [SerializeField]
    Text _Gameover;
    [SerializeField]
    Text _Rkeytext;
    GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score:" + 0;
        _Gameover.gameObject.SetActive(false);
        _Rkeytext.gameObject.SetActive(false);
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if(_gameManager == null)
        {
            Debug.LogError("Game Manager is null");
        }
    }

    public void UpdateScore(int playerscore)
    {
        _scoreText.text = "Score: " + playerscore;
    }

    public void UpdateLives(int currentlives)
    {
        _livesimg.sprite = _livesSprites[currentlives];

        if (currentlives < 1)
        {
            _gameManager.GameOver();
            _Rkeytext.gameObject.SetActive(true);
            _Gameover.gameObject.SetActive(true);
          
            StartCoroutine(FlashingGameOver());
          
        }
    }
    IEnumerator FlashingGameOver()
    {
        while (true)
        {
            _Gameover.text = "Game Over";
            yield return new WaitForSeconds(0.5f);
            _Gameover.text = "";
            yield return new WaitForSeconds(0.5f);
        }
        
    }
}