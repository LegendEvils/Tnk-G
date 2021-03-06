using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    private Text num;
    [SerializeField] Font countDownFont;

    // Start is called before the first frame update
    void Start()
    {
        num = GetComponent<Text>();
        num.font = countDownFont;
        StartCoroutine(Countdown(3));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Countdown(int seconds)
    {
        AudioManager.Instance.PlaySound("game/countdown");

        int count = seconds;

        yield return new WaitForSeconds(0.5f);
        while (count > 0)
        {
            // display something...
            num.text = count.ToString();

            yield return new WaitForSeconds(1);
            count--;
        }

        // count down is finished...
        num.text = "GO!";
        AudioManager.Instance.PlayMusicLoop("music/game");
        yield return new WaitForSeconds(1f);
        GameStats.Instance.isInputEnabled = true;
        gameObject.SetActive(false);
    }
}
