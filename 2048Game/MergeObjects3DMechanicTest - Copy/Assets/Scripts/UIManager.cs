using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text Score;
    [SerializeField] private TMP_Text HighScore;

    private int _score;

    private static UIManager _instance;
    public static UIManager Instance => _instance ?? (_instance = FindObjectOfType<UIManager>());


    public void ShowScore()
    {
        Score.text=(++_score).ToString();
    }


}
