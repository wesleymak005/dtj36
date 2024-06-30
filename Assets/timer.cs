using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{   
    public MovementScript movementScript;

    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime; 
    public bool countDown;

    [Header("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        
        if(hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
        {
            currentTime = timerLimit;
            SetTimerText();
            timerText.color = Color.white;
            enabled = false;

        }
        
        if (movementScript.playerStuck == true)
        {
            Penality();
            movementScript.playerStuck = false;
        }
        

        SetTimerText();
    }

    private void SetTimerText()
    {
        timerText.text = currentTime.ToString("0.0");
    }
    public void Penality()
    {
        currentTime -= 3;
    }
}
