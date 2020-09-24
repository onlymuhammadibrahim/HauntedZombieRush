using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    [SerializeField] public GameObject mainMenu;
    [SerializeField] public GameObject gameOverMenu;
    public int score = 0;
    public Text scoreText;
    public Text finalScore;

    private bool playerActive = false;
    private bool gameOver = false;
    private bool gameStarted = false;

    public bool PlayerActive
    {
        get { return playerActive; }
    }

    public bool GameOver
    {
        get { return gameOver; }
    }

    public bool GameStarted
    {
        get { return gameStarted; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        //DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlayerCollided()
    {
        gameOver = true;
        Invoke("feedDog", 3);
        scoreText.text = "";
        finalScore.text = "Score : " + score;
    }

    public void PlayerStartedGame()
    {
        playerActive = true;
    }
    public void EnterGame()
    {
        mainMenu.SetActive(false);
        gameStarted = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    
    private void feedDog()
    {
        gameOverMenu.SetActive(true);
    }
}
