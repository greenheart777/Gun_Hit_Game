using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private Animator anim;
    public int hp = 1;
    private int hp2;
    public int isDead;

    void Start()
    {
        isDead = 0;
        hp2 = hp;
        setRigidbodyState(true);
        setColliderState(false);
        GetComponent<Animator>().enabled = true;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (hp <= 0)
        {
            die();
        }

        if (hp == 0) isDead = 1;
    }

    public void die()
    {
        GetComponent<Collider>().enabled = false;
        //StartCoroutine(waiter());
        GetComponent<Animator>().enabled = false;
        setRigidbodyState(false);
        setColliderState(true);
        isDead = 1;


    }

    public void hitHP()
    {
        this.hp--;
    }

    void setRigidbodyState(bool state)
    {

        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = state;
        }

        GetComponent<Rigidbody>().isKinematic = !state;

    }


    void setColliderState(bool state)
    {

        Collider[] colliders = GetComponentsInChildren<Collider>();

        foreach (Collider collider in colliders)
        {
            collider.enabled = state;
        }

        GetComponent<Collider>().enabled = !state;
    }
    IEnumerator waiter()
    {
        yield return new WaitForSecondsRealtime(0.1f);
    }

    public void UpdateHP()
    {
        hp = hp2;
        isDead = 0;
        Debug.Log("Health Udpated");
    }
}
