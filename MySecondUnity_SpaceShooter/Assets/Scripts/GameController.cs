using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    
    public GameObject[] hazards;
    public Vector3 spanValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    //Extra if all harzaed of one wave are destroyed it add 50 points and bonus text is display
    //public Text bonusText;

    private bool restart;
    private bool gameOver;
    private int score;

    // Use this for initialization
    void Start()
    {

        //Inizialize variables
        score = 0;
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        //bonusText.text = "";

        StartCoroutine(SpawnWaves());
        UpdateScore();

    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {

            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spanValues.x, spanValues.x), spanValues.y, spanValues.z);
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(hazard, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnWait);

            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
        }
    }
    
    void UpdateScore()
    {
        scoreText.text = "Score " + score;

    }
    
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                //Application.LoadLevel(Application.loadedLevel);
                SceneManager.LoadScene("Main");
            }
        }
	}

    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }
    
    // Pup up a text Wave destroyed and a bonus in the point + 50
    //public void VaweDestroyed()
    //{
        
    //}
}
