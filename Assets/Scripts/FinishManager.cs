using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishManager : MonoBehaviour
{
    public Text WinnerText;
    void Start()
    {
        if (GameManager.instance)
        {
            WinnerText.text = GameManager.instance.GetWinner();
        }

    }
}
