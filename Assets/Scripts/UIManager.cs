using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsText;

    public void UpdateScoreText(int score)
    {
         pointsText.text = $"Points: {score}";
    }

}
