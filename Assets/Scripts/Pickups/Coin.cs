using UnityEngine;

public class Coin : PickUp
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    ScoreManager scoreManager;
    /*void Awake()
    {
      scoreManager=FindAnyObjectByType<ScoreManager>();  
    }*/
    public void Init(ScoreManager scoreManager)
    {
        this.scoreManager=scoreManager;
    }
    protected override void onPickup()
    {
        scoreManager.AddPoints();
    }
}
