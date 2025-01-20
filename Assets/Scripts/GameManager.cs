using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameActive = true;
    private int score = 0;
    private float scoreTimer = 0f;

    //UI om de score weer te geven
    [SerializeField] private TextMeshProUGUI scoreText;

    //UI voor game over
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject gameWinUI;


    public SoundScript sound;

    private void Start()
    {
        sound = GetComponent<SoundScript>();
        scoreText.text = "Score: " + score;
    }
    private void Update()
    {
        if (gameActive)
        {
            scoreTimer += Time.deltaTime;
        }

        if (scoreTimer >= 1f) //verhoogt elke seconde de score
        {
            score++;
            scoreTimer = 0f;
        }
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameActive = false;
        sound.PlayLoseSound();
        //zoekt alle enemies
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //vernietigt alle enemies
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

        //vernietig spawners
        GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");
        foreach (GameObject spawner in spawners)
        {
            Destroy(spawner);
        }

        //Toon Game over screen
        gameOverUI.SetActive(true);
    }

    public void GameWin()
    {
        gameActive = false;
        sound.PlayWinSound();
        
        //zoekt alle enemies
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

        //zoekt/vernietigt spawners
        GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");
        foreach (GameObject spawner in spawners)
        {
            Destroy(spawner);
        }

        gameWinUI.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    //checkt of player out of bounds is
}
