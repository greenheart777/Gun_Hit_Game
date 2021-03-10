using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRay : MonoBehaviour
{
    public float shootRate;
    public GameObject m_shotPrefab;
    private float m_shootRateTimeStamp;
    public AudioSource shotAudio;
    public AudioClip[] shotClip;

    RaycastHit hit;
    float range = 1000.0f;

    private void Start()
    {
        shotAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(WaypointController.inGame == false)
        {
            return;
        }

        if (Input.GetMouseButton(0)) //if pressed on touchscreen
        {
            if (Time.time > m_shootRateTimeStamp) // do this
            {
                shootRay();
                Handheld.Vibrate();
                m_shootRateTimeStamp = Time.time + shootRate;
            }
        }
    }

    //shooting bullet
    void shootRay()
    {
        Ray ray = new Ray(transform.position, transform.forward); // bullet output ray
        if (Physics.Raycast(ray, out hit, range))
        {
            EnemyControl enemy = hit.transform.GetComponent<EnemyControl>();
            if (enemy != null)
            {
                enemy.hitHP();
            }

            GameObject bullet = GameObject.Instantiate(m_shotPrefab, transform.position, Quaternion.identity) as GameObject; // Create bullet
            shotAudio.PlayOneShot(shotClip[Random.Range(0, shotClip.Length)]);
            bullet.GetComponent<BulletScript>().setTarget(hit.point); // Send collision position on BulletScript
            GameObject.Destroy(bullet, 10f);
        }
        
    }
}
