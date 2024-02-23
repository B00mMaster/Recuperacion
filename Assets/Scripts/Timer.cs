using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static float timer = 60f;
    public TextMeshProUGUI textTimer;

    private void Start()
    {
        StartCoroutine(Countdown());
    }

    //mientras el tiempo sea menor a 0, pasarán los segundos 1 a 1. A 0 se activa snakeDied
    IEnumerator Countdown()
    {
        while (timer > 0)
        {
            yield return new WaitForSeconds(1);
            timer--;
            textTimer.text = ("Timer:" + timer.ToString());

        }
        GameManager.Instance.SnakeDied();
    }
    //añade 5s al contador que baja cada segundo
    public void AddTime()
    {
        timer += 5;
        textTimer.text = ("timer:" + timer.ToString());
    }

}
