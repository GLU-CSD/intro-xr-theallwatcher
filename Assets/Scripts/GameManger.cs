using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameActive = true;
    private int score = 0;
    private float scoreTimer = 0f; // Timer om score te verhogen
    private float desCounter = 0f; // houdt het aantal vernietigde kristallen bij

    // UI om de score te laten zien
    [SerializeField] private TextMeshProUGUI scoreText;

    // UI die getoond wordt bij game over
    [SerializeField] private GameObject gameOverUI;

    // UI die getoond wordt bij game win
    [SerializeField] private GameObject gameWinUI;

    void Start()
    {
        scoreText.text = "Score: " + score;
    }
    void Update()
    {
        if (gameActive)
        {
            //Time.deltaTime geeft aantal seconden sinds laatste Update
            scoreTimer += Time.deltaTime;

            if (scoreTimer >= 1f) // Verhoog de score elke seconde
            {
                score++;
                scoreTimer = 0f; // Reset de timer
                scoreText.text = "Score: " + score;
            }

            if (desCounter >= 4f)
            {
                GameWin();
            }
        }
    }

    public void GameWin()
    {
        gameActive = false;
        Debug.Log("win");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log(enemies.Length);
        //Loop door alle gevonden vijanden en vernietig ze
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        gameWinUI.SetActive(true);
    }

    public void GameOver()
    {
        gameActive = false;
        Debug.Log("game over");
        // Vind alle vijanden in de scene
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log(enemies.Length);
        //Loop door alle gevonden vijanden en vernietig ze
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

        // Doe hetzelfde met de spawners
        GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");
        foreach (GameObject spawner in spawners)
        {
            Destroy(spawner);
        }

        // Toon de Game Over UI
        gameOverUI.SetActive(true);
    }

    public void CristalDes() { 
        score = score + 100;
        desCounter = desCounter + 1;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}