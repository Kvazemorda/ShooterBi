using UnityEngine;

public class Targert100 : MonoBehaviour
{
    public float health = 100f;
    public MeshCollider colliderOfTarget;
    public CloserScript closer;

    public void Damage (float amount)
    {
        if(health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        colliderOfTarget = GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
