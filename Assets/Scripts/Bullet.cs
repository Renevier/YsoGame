using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 1000f;

    public static event Action<float> OnEnemyHit;
    private float damage = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == ("Enemy"))
        {
            OnEnemyHit?.Invoke(damage);
            Destroy(gameObject);
        }
    }
}
