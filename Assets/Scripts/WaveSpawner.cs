using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;
    public Transform spawnPoint;

    public float wavecountdown = 5f;
    private float countdown = 2f;
    private int wavenumber = 0;

    public Text wavecountdownText;

    public GameManager gameManager;
    void Update()
    {
        if(EnemiesAlive > 0)
        {
            return;
        }
        if (wavenumber == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }
        if (countdown <= 0f)
        {
            StartCoroutine(spawnwave());
            countdown = wavecountdown;
            return;
        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        wavecountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator spawnwave()
    {
        Debug.Log("Wave Incoming!");
        
        PlayerStats.Rounds++;

        Wave wave = waves[wavenumber];

        EnemiesAlive = wave.count1 + wave.count2 + wave.count3;

        for (int i = 0; i < wave.count1; i++)
        {
            SpawnEnemy(wave.enemy1);
            yield return new WaitForSeconds(1f / wave.rate1);
        }
        for (int i = 0; i < wave.count2; i++)
        {
            SpawnEnemy(wave.enemy2);
            yield return new WaitForSeconds(1f / wave.rate2);
        }
        for (int i = 0; i < wave.count3; i++)
        {
            SpawnEnemy(wave.enemy3);
            yield return new WaitForSeconds(1f / wave.rate3);
        }       
        wavenumber++;

    }
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
