using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }        

    public CameraShake camShake;
    public int enemiesToKill;

    public TextMeshProUGUI gameText;
    public Image blackImg;

    void Awake()
    {
        //singleton pattern
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
    }

    void Start() 
    {
        StartCoroutine(StartGame());
    }

    public IEnumerator StartGame() 
    {
        float countdownTimer = 3f;

        for (int i = 3; i > 0; i--)
        {
            gameText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        gameText.text = "Go!";

        yield return new WaitForSeconds(1f);
        
        blackImg.gameObject.SetActive(false);
        gameText.text = "";
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.T)) 
        {
            SetEnemyKilled();
        }
    }

    public void ShakeCam() 
    {
        camShake.ShakeWrapper();
    }

    public void SetEnemyKilled() 
    {
        enemiesToKill--;

        if (enemiesToKill <= 0) 
        {
            EndGame("you successfully prevented all enemies from escaping!");
        }
    }

    public void EndGame(string gameMessage) 
    {
        blackImg.gameObject.SetActive(true);
        gameText.text = gameMessage;
    }
}
