using UnityEngine;

public abstract class PickUp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    const string playerString= "Player";
    [SerializeField] float rotationSpeed=100f;

    void Update()
    {
        transform.Rotate(0f, rotationSpeed*Time.deltaTime, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(playerString))
        {
            onPickup();
            Destroy(gameObject);
        }
    }

    protected abstract void onPickup();
}
