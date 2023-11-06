using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] public TMP_Text Score;

    private int _score;

    private static UIManager _instance;
    public static UIManager Instance => _instance ?? (_instance = FindObjectOfType<UIManager>());


    public void ShowScore()
    {
        Score.text=(++_score).ToString();

    }

    public void ReTry()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
