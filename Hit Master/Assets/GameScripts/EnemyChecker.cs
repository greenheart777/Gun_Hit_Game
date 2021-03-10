using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyChecker : MonoBehaviour
{
    public List<GameObject> enemys = new List<GameObject>();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemys[0].GetComponent<EnemyControl>().isDead == 1 && enemys[1].GetComponent<EnemyControl>().isDead == 1) {
            WaypointController.currentCheckpoint = 1;
        }
        if (enemys[2].GetComponent<EnemyControl>().isDead == 1 && enemys[3].GetComponent<EnemyControl>().isDead == 1 && enemys[4].GetComponent<EnemyControl>().isDead == 1)
        {
            WaypointController.currentCheckpoint = 2;
        }
        if (enemys[5].GetComponent<EnemyControl>().isDead == 1 && enemys[6].GetComponent<EnemyControl>().isDead == 1 
         && enemys[7].GetComponent<EnemyControl>().isDead == 1 && enemys[8].GetComponent<EnemyControl>().isDead == 1)
        {
            restartScene();
        }
    }

    public void restartScene()
    {
        enemys[0].GetComponent<EnemyControl>().UpdateHP();
        enemys[1].GetComponent<EnemyControl>().UpdateHP();
        enemys[2].GetComponent<EnemyControl>().UpdateHP();
        enemys[3].GetComponent<EnemyControl>().UpdateHP();
        enemys[4].GetComponent<EnemyControl>().UpdateHP();
        enemys[5].GetComponent<EnemyControl>().UpdateHP();
        enemys[6].GetComponent<EnemyControl>().UpdateHP();
        enemys[7].GetComponent<EnemyControl>().UpdateHP();
        enemys[8].GetComponent<EnemyControl>().UpdateHP();
        WaypointController.currentCheckpoint = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        WaypointController.inGame = true;
    }
}
