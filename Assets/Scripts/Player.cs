using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;

public class Player : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;

    [SerializeField] GameObject bullet;
    [SerializeField] Transform firepoint;
    [SerializeField] ParticleSystem lvlUpVfx;
    [SerializeField] ParticleSystem hurtVfx;

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Shoot();
    }

    private void Shoot()
    {
        GameObject go = Instantiate(bullet, firepoint.position, Quaternion.identity);
        go.transform.forward = transform.forward;
    }

    private void Rotate()
    {
        if(Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
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
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            hurtVfx.Play();
        }
    }
}
