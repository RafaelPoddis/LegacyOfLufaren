using UnityEngine;
using UnityEngine.SceneManagement;

public class TavernScript : MonoBehaviour
{
    private bool insideTavern = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            if (insideTavern)
            {
                Debug.Log("Saiu");
                insideTavern = false;
                SceneManager.LoadScene("Game");
            }
            else
            {
                Debug.Log("Entrou");
                insideTavern = true;
                SceneManager.LoadScene("Tavern");
            }
        }
    }
}
