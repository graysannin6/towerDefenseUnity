using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public static int AlienAlive = 0;
    public Transform spawnPoint;
    public float timeOfWaves = 5f;
    public float countdown = 0;
    private int waveNumber = 0;
    public Wave[] waves;
    public LifeManager lifemanager;

    public Text countSownWave;

    private void Update()
    {
        if (AlienAlive > 0)
        {
            return;
        }
        if (waveNumber == waves.Length)
        {
            lifemanager.WinLevel();
            this.enabled = false;
        }
        if (countdown <=0f)
        {
           StartCoroutine( WaveSpawn());
            countdown = timeOfWaves;
            return;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown,0f,Mathf.Infinity);
        countSownWave.text = string.Format("{0:00.00}",countdown);
    }
    IEnumerator WaveSpawn()
    {
        PlayerManager.Rounds++;
        Wave wave = waves[waveNumber];
        AlienAlive = wave.count;
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f/wave.rate);
        }
        waveNumber++;
      
    }

    private void SpawnEnemy(GameObject alien)
    {
        Instantiate(alien, spawnPoint.position,spawnPoint.rotation);
        
    }
}
