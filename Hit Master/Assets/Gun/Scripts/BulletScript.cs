using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Vector3 m_target;
    public GameObject collisionExplosion;
    public Transform target;
    public float speed;
    public float radius;
    public float force;

    private void Start()
    {
        // find to target object and rotate on there
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Target").transform;
        transform.LookAt(target); 
    }

    void Update()
    {        
        float step = speed * Time.deltaTime;
        
        if (m_target != null)
        {
            if (transform.position == m_target)
            {
                explode();
                explosion();
                explosion2();
                return;
            }
            transform.position = Vector3.MoveTowards(transform.position, m_target, step);
        }
    }

    public void setTarget(Vector3 target)
    {
        m_target = target;
    }

    void explode()
    {
        if (collisionExplosion != null)
        {
            GameObject explosion = (GameObject)Instantiate(collisionExplosion, transform.position, transform.rotation);
            Destroy(explosion);
        }
    }

    void explosion()
    {
        Collider[] overlappedColliders = Physics.OverlapSphere(transform.position, radius);
        for (int i = 0; i < overlappedColliders.Length; i++)
        {
            Rigidbody rigidbody = overlappedColliders[i].attachedRigidbody;
            if (rigidbody)
            {
                rigidbody.AddExplosionForce(force, transform.position, radius);
            }
            if (rigidbody)
            {
                rigidbody.AddExplosionForce(force * 0.8f, transform.position, radius);
            }
        }
        Debug.Log("Bang!");
        Destroy(gameObject);
    }

    void explosion2()
    {
        Collider[] overlappedColliders = Physics.OverlapSphere(transform.position, radius);
        for (int i = 0; i < overlappedColliders.Length; i++)
        {
            Rigidbody rigidbody = overlappedColliders[i].attachedRigidbody;
            if (rigidbody)
            {
                rigidbody.AddExplosionForce(force * 0.8f, transform.position, radius);
            }
        }
    }
}
