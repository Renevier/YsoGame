using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;

    [SerializeField] GameObject bullet;
    [SerializeField] Transform firepoint;
    [SerializeField] ParticleSystem lvlUpVfx;
    [SerializeField] ParticleSystem hurtVfx;

    [HideInInspector] public float damage = 10f;
    [SerializeField] private float fireRate;
    [HideInInspector] public float maxHp;

    private float currentXp = 0;
    [HideInInspector] public float lvl = 1;

    float timerShoot = 0f;
    [HideInInspector] public float currentHP;
    [HideInInspector] public float score = 0;
    private void Start()
    {
        currentHP = maxHp;
    }

    void Update()
    {
        currentHP = Mathf.Clamp(currentHP, 0f, maxHp);

        ManageXp();
        ManageDamage();

        timerShoot += Time.deltaTime;

        Rotate();
        Shoot();

        if (currentHP <= 0f)
            Destroy(gameObject);
    }

    public void EarnXp()
    {
        currentXp += 10f;
    }

    private void ManageXp()
    {
        if (currentXp >= lvl * 100)
        {
            currentXp = 0;
            lvl++;

            LvlUp();
        }
    }

    private void Shoot()
    {
        if (timerShoot >= fireRate)
        {
            GameObject go = Instantiate(bullet, firepoint.position, Quaternion.identity, transform);
            go.transform.forward = transform.forward;

            timerShoot = 0f;
        }
    }

    private void Rotate()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, (1 << LayerMask.NameToLayer("Ground"))))
                {
                    Vector3 positionToLookAt = hit.point;

                    agent.transform.LookAt(new Vector3(positionToLookAt.x, transform.position.y, positionToLookAt.z));
                }
            }
        }
    }

    private void LvlUp()
    {
        lvlUpVfx.Play();
        currentHP += maxHp;

        ManageMaxHealth();
    }

    public void TakeDamage(float _damage)
    {
        currentHP -= _damage;
        hurtVfx.Play();
    }

    private void ManageDamage()
    {
        damage = lvl * 10;
    }
    private void ManageMaxHealth()
    {
        maxHp = lvl * 100;
    }
}
