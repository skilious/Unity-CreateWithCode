using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float spawnRate = 1.0f;
    private int score;

    public List<GameObject> targets;
    public Text scoreText;
    public Text gameOverText;
    public bool isGameOver;
    public GameObject restartButton;
    public GameObject titleScreen;

    private GameManager _instance;
    public static GameManager instance;

    private void Awake()
    {
        isGameOver = true;
        restartButton.SetActive(false);
        gameOverText.enabled = false;
        _instance = this;
        if(_instance != null)
        {
            instance = _instance;
        }
    }

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        titleScreen.SetActive(false);
        isGameOver = false;
        score = 0;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        restartButton.SetActive(true);
        gameOverText.enabled = true;
        isGameOver = true;
    }
    private IEnumerator SpawnTarget()
    {
        while(!isGameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            UpdateScore(5);
        }
    }

    public void RestartGame()
    {
        print("Restarted");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
