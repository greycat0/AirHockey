using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private int counter1, counter2;
    private Text countText1, countText2;
    private string winner;

    void Start()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        GameObject.Find("Count1").GetComponent<Text>().text = counter1.ToString();
        GameObject.Find("Count2").GetComponent<Text>().text = counter2.ToString();
        DontDestroyOnLoad(gameObject);
    }
    public void IncCounter1()
    {
        counter1++;
        if (checkCount())
        {
            GameObject.Find("Count1").GetComponent<Text>().text = counter1.ToString();
        }
    }
    public void IncCounter2()
    {
        counter2++;
        if (checkCount())
        {
            GameObject.Find("Count2").GetComponent<Text>().text = counter2.ToString();
        }
    }
    private bool checkCount()
    {
        if (counter1 >= 5)
        {
            counter1 = 0;
            counter2 = 0;
            winner = "Player1";
            SceneManager.LoadScene(2);
            return false;
        }
        if (counter2 >= 5)
        {
            counter1 = 0;
            counter2 = 0;
            winner = "Player2";
            SceneManager.LoadScene(2);
            return false;
        }
        return true;
    }
    public string GetWinner()
    {
        return winner;
    }
}
