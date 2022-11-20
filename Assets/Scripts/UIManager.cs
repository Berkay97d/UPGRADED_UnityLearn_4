using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private static int score;

    [SerializeField] private TMP_Text endScoreText;
    [SerializeField] private TMP_Text bestScoreText;
    private static int bestScore = 0;

    [SerializeField] private Canvas inGame;
    [SerializeField] private Canvas endGame;


    private void Update()
    {
        HandleUI();
    }

    private void HandleUI()
    {
        scoreText.text = score.ToString();
        endScoreText.text ="Score: " + score.ToString();

        if (score > bestScore)
        {
            bestScore = score;
        }

        bestScoreText.text = "Best Score: " + bestScore;
    }

    public static void GetScore()
    {
        score++;
    }

    public void ActivateLoseCanvas()
    {
        inGame.gameObject.SetActive(false);
        endGame.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        score = 0;
        SceneManager.LoadScene(0);
    }


}
