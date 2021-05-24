using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject homePanel;
    public GameObject controlPanel;
    public GameObject scorePanel;
    public GameObject gameoverPanel;
    public GameObject rulesPanel;
    public GameObject rulesPanel2;

    public GameObject enemySpawner;
    public GameObject obstacleSpawner;

    public bool gameStarted;

    private void Start()
    {
        gameStarted = false;
        enemySpawner.SetActive(false);
        obstacleSpawner.SetActive(false);
    }
    public void StartGame()
    {
        gameStarted = true;
        homePanel.SetActive(false);
        controlPanel.SetActive(false);
        rulesPanel.SetActive(false);
        scorePanel.SetActive(true);
        gameoverPanel.SetActive(false);
        FindObjectOfType<FirewallMover>().StartMoving();
        enemySpawner.SetActive(true);
        obstacleSpawner.SetActive(true);
    }

    public void GoHome()
    {
        homePanel.SetActive(true);
        controlPanel.SetActive(false);
        rulesPanel.SetActive(false);
        scorePanel.SetActive(false);
        gameoverPanel.SetActive(false);
        rulesPanel2.SetActive(false);
    }

    public void Restart()
    {
        homePanel.SetActive(true);
        controlPanel.SetActive(false);
        scorePanel.SetActive(false);
        rulesPanel.SetActive(false);
        gameoverPanel.SetActive(false);
        FindObjectOfType<FirewallMover>().ResetFirewall();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Gameover() 
    {
        homePanel.SetActive(false);
        controlPanel.SetActive(false);
        scorePanel.SetActive(false);
        rulesPanel.SetActive(false);
        gameoverPanel.SetActive(true);
        gameStarted = false;
        FindObjectOfType<FirewallMover>().StopMoving();
        enemySpawner.SetActive(false);
        obstacleSpawner.SetActive(false);
    }

    public void RulePage2()
    {
        homePanel.SetActive(false);
        controlPanel.SetActive(false);
        scorePanel.SetActive(false);
        rulesPanel.SetActive(false);
        gameoverPanel.SetActive(false);
        rulesPanel2.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenControl()
    {
        homePanel.SetActive(false);
        controlPanel.SetActive(true);
        scorePanel.SetActive(false);
        rulesPanel.SetActive(false);
        gameoverPanel.SetActive(false);
    }

    public void OpenRules()
    {
        homePanel.SetActive(false);
        controlPanel.SetActive(false);
        rulesPanel2.SetActive(false);
        scorePanel.SetActive(false);
        rulesPanel.SetActive(true);
        gameoverPanel.SetActive(false);
    }
}
