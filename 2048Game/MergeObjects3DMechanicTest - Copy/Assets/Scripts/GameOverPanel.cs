using System;
using TMPro;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private GameObject GameOver;
    [SerializeField] private TMP_Text HighScore;
    private bool isInside;

    private float timer = 0f;
    private float requiredTime = 3f;

    private void Update()
    {
        if (isInside)
        {
            timer += Time.deltaTime;
            if (timer >= requiredTime)
            {
                GameOver.SetActive(true);

                if (Int32.Parse(UIManager.Instance.Score.text) > PlayerPrefs.GetInt("HighScore"))
                {
                    PlayerPrefs.SetInt("HighScore", Int32.Parse(UIManager.Instance.Score.text));
                }

                HighScore.text = PlayerPrefs.GetInt("HighScore").ToString();
                GameObject.FindGameObjectWithTag("Score").gameObject.SetActive(false);
                Time.timeScale = 0;
                timer = 0f;
            }
        }
        else
        {
            timer = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isInside = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isInside = false;
        timer = 0f;
    }
}
