using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject exitObjective;
    public static int theScore;
    public int goldNeeded;

    void Update()
    {
        if (theScore == 0)
        {
            scoreText.GetComponent<Text>().text = "";
        }
        else if (theScore == 1) {
            scoreText.GetComponent<Text>().text = theScore + " gold bar collected";
        } 
        else
        {
            scoreText.GetComponent<Text>().text = theScore + " gold bars collected";
        }
        
        if (theScore >= goldNeeded)
        { 
            exitObjective.SetActive(true);
            exitObjective.GetComponent<Objective>().title = "Hoera";
            exitObjective.GetComponent<Objective>().description = "Gefeliciteerd";
            exitObjective.GetComponent<Objective>().UpdateObjective("Description", "CounterText", "");
        }
    }
}
