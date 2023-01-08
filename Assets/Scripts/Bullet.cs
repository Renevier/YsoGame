using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    
    private float damage;
    private Player player;

    private void Start()
    {
        player = GetComponentInParent<Player>();
        damage = player.damage;

        transform.parent = null;
    }

    void Update()
    {
        rb.velocity = transform.forward * speed * Time.deltaTime;

        Ray ray = new Ray(transform.position, Vector3.down);

        if(!Physics.Raycast(ray, Mathf.Infinity, (1 << LayerMask.NameToLayer("Ground"))))
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == ("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
