using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private int score = 0;
    [Serialize field] private TextMeshProUGUI scoreText;
    [Serialize field] private TextMeshProUGUI gameOverText;
    [Serialize field] private GameObject titleScreen;
    [Serialize field] private Button restartButton;
    [Serialize field] private List<GameObject> targets;
    private float spawnRate = 1.0f;
    public bool gameOver {get; private set;}

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        titleScreen.SetActive(false);
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
    }

    /
    private IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
