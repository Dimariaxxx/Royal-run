using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float increaseTime=5;
    GameManager gameManager;

    string playerTag="Player";

    void Awake()
    {
        gameManager=FindFirstObjectByType<GameManager>();

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag==playerTag)gameManager.TimeLeft=increaseTime;
    }
}
