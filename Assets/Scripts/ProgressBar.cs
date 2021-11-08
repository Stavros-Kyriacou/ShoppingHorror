using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Image progressImage;
    public float fillAmount;
    public float currentTime = 0f;
    public float timeToComplete;
    public bool isComplete = false;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !isComplete)
        {
            IncreaseProgress();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ResetProgress();
        }
    }

    private void IncreaseProgress()
    {
        currentTime += Time.deltaTime;
        UpdateProgressBar();

        if (currentTime >= timeToComplete)
        {
            isComplete = true;
        }
    }
    private void ResetProgress()
    {
        isComplete = false;
        currentTime = 0f;
        UpdateProgressBar();
    }
    public void UpdateProgressBar()
    {
        fillAmount = currentTime / timeToComplete;
        progressImage.fillAmount = fillAmount;
    }
}
