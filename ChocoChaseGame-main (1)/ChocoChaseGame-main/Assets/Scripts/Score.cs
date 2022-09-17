using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public int score;
    [SerializeField] private Text scoreText = null;
    public AudioSource sweetCollectible;
   

    // Start is called before the first frame update
    void Start()
    {
      
        scoreText.text = "Level1:   Happy Bar:" + 0;
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Negative"))
        {
            score=score - 5;
            Destroy(other.gameObject);
            updateScore(score);
        }

        if (other.gameObject.CompareTag("Positive"))
        {
            
            sweetCollectible.Play(); 
            score =score+ 10;
            Debug.Log("collided");
            Destroy(other.gameObject);
            Debug.Log(score);
            updateScore(score);
        }


        Debug.Log(score);
      // if (score > 30)
         //  SceneManager.LoadScene("level02");

    }

    public void updateScore(int points)
    {
      
        scoreText.text = "Level1:   Happy Bar:" + points;
    }
}