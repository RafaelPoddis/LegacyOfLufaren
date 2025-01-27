using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pause;
    [SerializeField] GameObject settings;
    [SerializeField] GameObject inventory;
    [SerializeField] GameObject statsPanel;
    [SerializeField] GameObject characterPanel;
    [SerializeField] GameObject mapCanvas;
    [SerializeField] AudioSource music;

    private bool isPaused = false;
    private bool inventoryOpen = false;
    private bool statsOpen = false;
    private bool mapOpen = false;
    private bool isMuted = false;

    void Start()
    {
        pause.SetActive(false);
        settings.SetActive(false);
        inventory.SetActive(false);
        mapCanvas.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                PauseGame();
            }
        }

        if (Input.GetKeyUp(KeyCode.I))
        {
            Inventory();
        }

        if (Input.GetKeyUp(KeyCode.M))
        {
            Map();
        }
    }

    public void Resume()
    {
        pause.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void PauseGame()
    {
        pause.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        isPaused = false;
    }

    public void Settings()
    {
        // inSettings = true;
        settings.SetActive(true);
    }

    public void ExitStettings()
    {
        // inSettings = false;
        settings.SetActive(false);
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Inventory()
    {
        if (inventoryOpen)
        {
            Time.timeScale = 1f;
            inventoryOpen = false;
            inventory.SetActive(false);
        }
        else
        {
            inventoryOpen = true;
            Time.timeScale = 0f;
            inventory.SetActive(true);
        }
    }

    public void ChangePanel()
    {
        if (statsOpen)
        {
            statsOpen = false;
            characterPanel.SetActive(true);
        }
        else
        {
            statsOpen = true;
            characterPanel.SetActive(false);
        }
    }

    public void Map()
    {
        if (mapOpen)
        {
            mapOpen = false;
            mapCanvas.SetActive(false);
        }
        else
        {
            mapOpen = true;
            mapCanvas.SetActive(true);
        }
    }

    public void Mute()
    {
        if (isMuted)
        {
            isMuted = false;
            music.volume = 1f;
        }
        else
        {
            isMuted = true;
            music.volume = 0f;
        }
    }
}
