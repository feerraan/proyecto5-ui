using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
     [SerializeField] private GameObject[] targetPrefabs;

     private float minX = -3.75f;
     private float minY = -3.75f;
     private float distanceBetweenCenters = 2.5f;

     private bool isGameOver;
     private float spawnRate = 1f; // Los targets aparecerán cada 2 segundos

     private Vector3 randomPos;

     private int score;

     private UIManager uiManager;

     public List<Vector3> targetPositionsInScene;

     private void Awake()
     {
          targetPositionsInScene = new List<Vector3>();
     }

     private void Start()
     {
          uiManager = FindObjectOfType<UIManager>();

          uiManager.HideGameOverPanel();

          score = 0;
          UpdateScore(0);

          StartCoroutine(SpawnRandomTarget());
     }

     private Vector3 RandomSpawnPosition()
     {
          // -3.75, -1.25, 1.25, 3.75
          float spawnPosX = minX + Random.Range(0, 4) * distanceBetweenCenters;
          float spawnPosY = minY + Random.Range(0, 4) * distanceBetweenCenters;

          return new Vector3(spawnPosX, spawnPosY, 0);
     }

     private IEnumerator SpawnRandomTarget()
     {
          while (!isGameOver)
          {
               yield return new WaitForSeconds(spawnRate);

               if (isGameOver)
               {
                    break;
               }

               int randomPrefabsIndex = Random.Range(0, targetPrefabs.Length);
               
               randomPos = RandomSpawnPosition();
               while (targetPositionsInScene.Contains(randomPos))
               {
                    randomPos = RandomSpawnPosition();
               }
               
               Instantiate(targetPrefabs[randomPrefabsIndex], 
                         randomPos,
                         targetPrefabs[randomPrefabsIndex].transform.rotation);

               targetPositionsInScene.Add(randomPos);
          } 
     }

     public void UpdateScore(int newPoints)
     {
          score += newPoints;
          uiManager.UpdateScoreText(score);
          
          if (score < 0) 
          {
               isGameOver = true;
               uiManager.ShowGameOverPanel();
          }
     }

     public bool IsGameOver()
     {
          return isGameOver;
     }
}
