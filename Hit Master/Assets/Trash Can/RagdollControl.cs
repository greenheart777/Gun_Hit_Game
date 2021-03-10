using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollControl : MonoBehaviour
{
    public Animator Animator;
    public Rigidbody[] AllRigibodys;

    void Awake()
    {
        for (int i = 0; i < AllRigibodys.Length; i++){
            AllRigibodys[i].isKinematic = true;
        }    
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MakePhysical();
        }
    }

    public void MakePhysical()
    {
        Animator.enabled = false;
        for (int i = 0; i < AllRigibodys.Length; i++){
            AllRigibodys[i].isKinematic = false;
        }
    }
}
