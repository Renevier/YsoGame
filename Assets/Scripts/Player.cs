using System;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;

    [SerializeField] GameObject bullet;
    [SerializeField] Transform firepoint;

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
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, (1 << LayerMask.NameToLayer("Ground"))))
                {
                    Vector3 positionToLookAt = hit.point;

                    agent.transform.LookAt(positionToLookAt);
                }
            }
        }
    }
}
