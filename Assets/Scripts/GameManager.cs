using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameHasEnded = false;

    public GameObject levelWinUI;

    private void Update()
    {
        EndGame();
    }
    public void EndGame()
    {
        if (gameHasEnded)
        {
            gameHasEnded = false;
            Invoke(nameof(Restart), 2);
        }
    }

    public void GameWin()
    {
        levelWinUI.SetActive(true);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
