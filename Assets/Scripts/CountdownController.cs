using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{
    [SerializeField] int count;
    [SerializeField] string textOnEnd = "GO!";
    [SerializeField] Text countdownText;


    public IEnumerator CountdownToStart()
    {
        while (count > 0)
        {
            countdownText.text = count.ToString();

            yield return new WaitForSeconds(1f);

            count--;
        }
        countdownText.text = textOnEnd;
        
        yield return new WaitForSeconds(1f);

        countdownText.gameObject.SetActive(false);

        GameController.Instance.StartGame();

    }

}
