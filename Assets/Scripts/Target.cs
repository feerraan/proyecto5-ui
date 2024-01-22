using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float lifeTime = 2f;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        Destroy(gameObject, lifeTime);
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        gameManager.targetPositionsInScene.Remove(transform.position);
    }
}
