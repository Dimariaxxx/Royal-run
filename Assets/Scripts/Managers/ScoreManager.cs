using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] TMP_Text score;
    [SerializeField] GameManager gameManager;
    int scoreTXT=0;
    public void AddPoints()
    {
        if(!gameManager.GameOver)
        {
            scoreTXT+=10;
            score.text=scoreTXT.ToString();
        }
    }


}
