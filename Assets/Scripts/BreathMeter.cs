using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class BreathMeter : MonoBehaviour
{
    private Slider slider;
    float currentBreath = 0;
    float breatheInRate = 1.0f;
    float breatheOutRate = 1.0f;
    float maxLevel = 4;
    int mode = 1;

    void Start() {
        slider = GetComponent<Slider>();
        slider.maxValue = maxLevel;
        slider.value = 0;
        StartCoroutine(IncreaseMeter());
    }

    // public void SetMaxBreathLevel(float maxLevel)
    // {
    // }

    // public void SetLevel(float level)
    // {
    //     slider.value = level;
    // }

    // void Update ()
    // {
    //     print(currentBreath);
    //     if (currentBreath - breatheOutRate >= 0 && breathingOut == true) {
    //         breathingIn = false;
    //         breathingOut = true;
    //         StartCoroutine(BreatheOut());
    //     } else {
    //         breathingIn = true;
    //         breathingOut = false;
    //         StartCoroutine(BreatheIn());
    //     }
    // }

    private IEnumerator DecreaseMeter() {
        CheckMode();
        while(currentBreath >= 0) {
            currentBreath -= breatheOutRate/10;
            slider.value = currentBreath;
            yield return new WaitForSeconds(0.1f);
            print("waiting out");
        }
        mode++;
        StartCoroutine(IncreaseMeter());
    }

    private IEnumerator IncreaseMeter() {
        CheckMode();
        while(currentBreath < maxLevel) {
            currentBreath += breatheInRate/10;
            slider.value = currentBreath;
            yield return new WaitForSeconds(0.1f);
            print("waiting in");
        }
        mode++;
        StartCoroutine(DecreaseMeter());
    }
    
    private void CheckMode() {
        int calcMode = mode % 4;
        print(calcMode);
        if (calcMode == 1) {
            slider.transform.GetChild(2).gameObject.SetActive(true);
            slider.transform.GetChild(3).gameObject.SetActive(false);
            slider.transform.GetChild(4).gameObject.SetActive(false);
        } else if (calcMode == 2 || calcMode == 0) {
            slider.transform.GetChild(4).gameObject.SetActive(true);
            slider.transform.GetChild(2).gameObject.SetActive(false);
            slider.transform.GetChild(3).gameObject.SetActive(false);
        } else {
            slider.transform.GetChild(3).gameObject.SetActive(true);
            slider.transform.GetChild(2).gameObject.SetActive(false);
            slider.transform.GetChild(4).gameObject.SetActive(false);
        }
    }
}
