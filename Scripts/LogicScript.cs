using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LogicScript : MonoBehaviour
{
    public int Score;
    public Text Scoretext;
    public Text JustScore;
    public Text HighScoreText;
    public GameObject overscreen;
    public GameObject birdScene;
    public GameObject launchingpipe;
    public GameObject openingText;
    public GameObject closingtext;
    private bool onlyOneTime = true;
    public static bool levelup = false;

    public AudioClip soundEffect;

    private int highScore = 0;

    private void Start()
    {
        //PlayerPrefs.DeleteKey("HighScore");
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        HighScoreText.color = new Color(0, 1, 92f / 255f, 1);
        HighScoreText.text = "High Score: " + highScore;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
        if (Score > highScore)
        {
            HighScoreText.text = "High Score: " + Score;
        }
        if (Input.anyKeyDown && onlyOneTime )
        {
            //Adjusting HighScoreText
            HighScoreText.color = new Color(17f / 255f, 17f / 255f, 17f / 255f, 1);
            HighScoreText.rectTransform.localPosition = new Vector3(-573, -19.8f, 0);
            HighScoreText.fontSize = 53;

            //

            JustScore.color = new Color(43f / 255f, 43f / 255f, 43f / 255f, 1);
            Scoretext.color = new Color(0, 0, 0, 1);
            
            birdScene.SetActive(true);
            launchingpipe.SetActive(true);
            openingText.SetActive(false);
            closingtext.SetActive(false);
            onlyOneTime = false;
        }
        if (Score % 5 == 0 && Score != 0 && levelup && CollectedPipe.currentSpawnRate > 0.5f)
        {
            IndividualPipe.globalSpeed += 2;
            CollectedPipe.currentSpawnRate -= 0.5f;
            levelup = false;
        }
    }
    public void add(int points)
    {
        Score += points;
        Scoretext.text = Score.ToString();
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void gameOver() {
        CollectedPipe.levelup = false;
        CheckAndSaveHighScore();
        overscreen.SetActive(true);
        IndividualPipe.globalSpeed = 2;
        CollectedPipe.currentSpawnRate = 6;
        BgImageScrpit.globalSpeed = 2;
            }

    void CheckAndSaveHighScore()
    {
        if (Score > highScore)
        {
            highScore = Score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
        HighScoreText.text = "High Score: " + highScore;
    }
}
