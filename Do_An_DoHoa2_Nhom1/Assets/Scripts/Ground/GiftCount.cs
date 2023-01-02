using UnityEngine;
using UnityEngine.UI;

public class GiftCount : MonoBehaviour
{
    public Text scoreText;
    public Text score;
    private int countGifts;
   // private int sumScore;
    void Start()
    {
        countGifts = 0;
      //  sumScore = 0;
        setCountText();
        FindObjectOfType<GameManager>().showGamePanel(false);
    }
    void setCountText()
    {
        scoreText.text = "Gift: " + countGifts.ToString();
    }
    //void setScore()
    //{
    //    score.text = "Score: " + sumScore.ToString();
    //}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Gift")
        {
            other.gameObject.SetActive(false);
            countGifts = countGifts + 1;
          //  sumScore = sumScore + 1;
            setCountText();
           // setScore();
        }
    }
}
