using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Animator animator; 
    [SerializeField] float adjustMoveSpeed=-2f;
    const string triggerTwerk="Hit";
    const int coolDownPeriodInSeconds=1;
    float timeStamp=0f;
    LevelGenerator levelGenerator;
    void Start()
    {
        levelGenerator=FindAnyObjectByType<LevelGenerator>();
    }
    void OnCollisionEnter(Collision other)
    {
        if(Time.time>=timeStamp)
        {
            levelGenerator.ChangeChunkMoveSpeed(adjustMoveSpeed);
            animator.SetTrigger(triggerTwerk);
            timeStamp = Time.time + coolDownPeriodInSeconds;
        }
    }
}
