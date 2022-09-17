using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreEdit : MonoBehaviour
{
    public string LevelToLoad;
    public string LevelOver;
    public string thisLevel;
    public GameObject gameObject1;
  
    public GameObject gameObject3;
    public int score;
    public AudioSource sweetCollectible;
    public AudioSource notsweetCollectible;
    public AudioSource GameOver;

    [SerializeField] public Text scoreText = null;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Happy Bar: " + 0;
    }

    // Update is called once per frame
    void Update()
    {
      
       

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Negative")
        {
            score -= 10;
            Destroy(other.gameObject);
            updateScore(score);
            notsweetCollectible.Play();
        }

        if (other.gameObject.tag == "Positive")
        {
            score += 10;
            sweetCollectible.Play();

            Destroy(other.gameObject);
            updateScore(score);
        }
        if (other.gameObject.CompareTag("HaltWall") && score > 10)
        {
            gameObject1.SetActive(true);
            //gameObject2.SetActive(true);
        }


            Debug.Log(score);
        // if (score > 30)
        // {
        //    gameObject1.SetActive(true);

         
       if (score < 0)
        {
           
       
          
           // SceneManager.LoadScene(thisLevel);
            Time.timeScale = 0f;//gamefreeze
            gameObject3.SetActive(true);
            GameOver.Play();


        }

    }

    public void updateScore(int points)
    {
        scoreText.text = "Happy Bar: " + points;
    }
}