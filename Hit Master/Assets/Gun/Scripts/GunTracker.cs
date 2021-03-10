using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTracker : MonoBehaviour
{
    public Transform Pointer;
    public Transform target;
    public float speed = 5.0f;

    void Start()
    {
        
    }

    // This script rotate gun to screen touch position
    void Update()
    {
        if (WaypointController.inGame == false)
        {
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // mouse position Ray
        Debug.DrawRay(transform.position, transform.forward * 100f, Color.yellow); // debug Ray

        // Pointer is position where look at our gun
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) Pointer.position = hit.point;

        // Look at touch position
        Vector3 direction = target.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
}
