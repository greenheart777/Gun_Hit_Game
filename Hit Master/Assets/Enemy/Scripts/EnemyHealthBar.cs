using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    private Camera cameraToLookAt;
    private new GameObject camera;
    public float health;
    public float maxHealth;
    public Slider slider;
    public GameObject my;
    public GameObject healthBar;


    private void Awake()
    {
        maxHealth = my.GetComponent<EnemyControl>().hp;
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        cameraToLookAt = camera.GetComponent<Camera>();
    }
    private void Start()
    {
        if (maxHealth < 2) {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        health = my.GetComponent<EnemyControl>().hp;
        Vector3 v = cameraToLookAt.transform.position - transform.position;
        v.x = v.z = 0.0f;
        transform.LookAt(cameraToLookAt.transform.position - v);
        transform.Rotate(0, 180, 0);
        slider.value = CalculateHealth();

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if (health > maxHealth)
        {
            maxHealth = health;
        }
    }

    float CalculateHealth()
    {
        return health / maxHealth;
    }
}
