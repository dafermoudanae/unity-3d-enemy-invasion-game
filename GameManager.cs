using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool ended = false;

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (!ended) return;

        if (Input.GetKeyDown(KeyCode.P))
            Restart();

    }

    public void WinCheck()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log("Enemies remaining: " + (enemies.Length - 1)); // LENGHT -1 ΓΙΑΤΙ ΜΕ ΣΚΕΤΟ LENGHT ΔΕΝ ΤΕΡΜΑΤΙΖΕ ΠΟΤΕ 

        if ((enemies.Length -1) == 0)
            Win();
    }

    public void Win()
    {
        if (ended) return;
        ended = true;
        Debug.Log("VICTORY!!:)");
        Time.timeScale = 0f;
    }


    public void Lose()
    {
        if (ended) return;
        ended = true;

        Debug.Log("DEFEAT!:(");
        Time.timeScale = 0f;
    }



    void Restart()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
        );
    }

}
