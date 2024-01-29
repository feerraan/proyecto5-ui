using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float lifeTime = 2f;
    [SerializeField] private int points;
    [SerializeField] private GameObject explosionParticle;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        Destroy(gameObject, lifeTime);
    }

    private void OnMouseDown()
    {
        if (!gameManager.IsGameOver())
        {
            gameManager.UpdateScore(points);
            Instantiate(explosionParticle, 
                        transform.position,
                        Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        gameManager.targetPositionsInScene.Remove(transform.position);
    }
}
