using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] TMP_Text timeText;
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject gameOverText;
    [SerializeField] float startTime=5f;
    float timeLeft;
    bool gameOver=false;
    //public bool GameOver{get{return gameOver;}}
    //public bool GameOver{get; private set;}
    public bool GameOver{get=>gameOver;set => gameOver = value;}
    public float TimeLeft{get=>timeLeft;set => timeLeft += value;}

    void Start()
    {
        timeLeft=startTime;
    }
    void Update()
    {
        bool flowControl = DecreaseTime();
        if (!flowControl)
        {
            return;
        }
    }
    
    

    private bool DecreaseTime()
    {
        if (gameOver) return false;

        timeLeft -= Time.deltaTime;
        timeText.text = timeLeft.ToString("F1");

        if (timeLeft <= 0f)
        {
            PlayerGameOver();
        }

        return true;
    }

    void PlayerGameOver()
    {
        gameOver=true;
        gameOverText.SetActive(true);
        Time.timeScale=0.3f;
        Time.fixedDeltaTime = 0.002f;
        playerController.enabled=false;
    }
}
