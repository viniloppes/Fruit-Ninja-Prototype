using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> targets;
    [SerializeField] private float spawnRate = 1.0f;

    private int score = 0;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreTMP;
    public TextMeshProUGUI livesTMP;
    public GameObject restartButton;
    public bool isGameActive = false;

    private int lives = 0;
    public GameObject titleScreen;
    // Start is called before the first frame update
    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        restartButton.SetActive(false);
        // StartGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);

        }

    }

    public void AddPoint(int points)
    {
        score += points;
        scoreTMP.text = "Score: " + score;

    }

    public void GameOver()
    {
        restartButton.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void StartGame(int difficult)
    {
        UpdateLives(3);
        isGameActive = true;
        spawnRate /= difficult;
        score = 0;
        StartCoroutine(SpawnTarget());
        AddPoint(0);
   
        titleScreen.SetActive(false);

    }

    public void UpdateLives(int livesToUpdate)
    {
        lives += livesToUpdate;
        livesTMP.text = "Lives: " + lives;
        if (lives <= 0)
        {
            GameOver();
        }
    }
}
