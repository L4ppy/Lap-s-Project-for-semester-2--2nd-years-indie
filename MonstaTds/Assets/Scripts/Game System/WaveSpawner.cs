using System.Collections;
using System.Collections.Generic;
using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;
    public GameObject spawnEffect;
    public float timeBetweenWaves = 10f;
    private float countdown = 2f;

    public TextMeshProUGUI  waveCountDownText;
    private int waveNumber = 1;
    private int waveIndex = 0;

    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
        waveCountDownText.text = "Next wave in: " + Mathf.Floor(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;

        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        waveNumber++;
    }

    private void SpawnEnemy()
    {
        //GameObject effectIns = (GameObject)Instantiate(spawnEffect, spawnPoint.position, new Transform(spawnPoint.position, spawnPoint.rotation.x);
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
