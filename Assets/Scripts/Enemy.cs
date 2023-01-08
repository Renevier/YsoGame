using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private float maxHealth;
    private float health;

    [HideInInspector] public Player player;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject exp;

    private float damage;

    private void Start()
    {
        ManageMaxHealth();
        ManageDamage();

        health = maxHealth;
    }

    private void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.transform.position);

            if (Vector3.Distance(player.transform.position, transform.position) <= 4.5f)
                Explode();
        }

        if (health <= 0f)
        {
            Destroy(gameObject);
            GameObject go = Instantiate(exp, transform.position, Quaternion.identity);
            go.GetComponent<Exp>().player = player;
            player.score++;
        }

    }

    public void TakeDamage(float _damages)
    {
        health -= _damages;
    }

    private void Explode()
    {
        Collider[] player = Physics.OverlapSphere(transform.position, 20f, (1 << LayerMask.NameToLayer("Player")));

        foreach (var i in player)
            i.GetComponent<Player>().TakeDamage(damage);

        Destroy(gameObject);
    }


    private void ManageMaxHealth()
    {
        maxHealth = player.lvl * 100;
    }

    private void ManageDamage()
    {
        damage = player.lvl * 10;
    }
}
