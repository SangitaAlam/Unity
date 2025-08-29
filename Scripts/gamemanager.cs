using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class gamemanager : MonoBehaviour
{
    public GameObject Restart; // drag your text here in Inspector
    private bool isGameOver = false;

    void Start()
    {
        Restart.SetActive(false); // hide at start
    }

    public void GameOver()
    {
        isGameOver = true;
        Restart.SetActive(true); // show "Press F to play again"
    }

    void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.F))
        {
            RestartGame();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
