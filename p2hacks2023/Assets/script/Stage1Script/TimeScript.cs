using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    //前回Update時の秒数
	private float oldSeconds;
	//　トータル制限時間
	public static float totalTime;
	//　制限時間（分）
	[SerializeField]
	private int minute;
	//　制限時間（秒）
	[SerializeField]
	private float seconds;

	// 時間切れ時に表示するパネル
	[SerializeField]
	private GameObject GameOverPanel;
	
	private Text timerText;

	//テキストが表示中かどうか
	public static bool isText = false;
    
    // Start is called before the first frame update
    void Start()
    {
        totalTime = minute * 60 + seconds;
		oldSeconds = 0f;
		timerText = GetComponentInChildren <Text> ();
		timerText.text = minute.ToString("00") + ":" + ((int) seconds).ToString("00");
    }

    // Update is called once per frame
    void Update()
    {
        //　制限時間が0秒以下なら何もしない
		if (totalTime <= 0f) {
			return;
		}

		//	テキストが表示中でなければタイムを進める
		if(isText == false)
		{
			//　一旦トータルの制限時間を計測；
			totalTime = minute * 60 + seconds;
			totalTime -= Time.deltaTime;


			//　再設定
			minute = (int) totalTime / 60;
			seconds = totalTime - minute * 60;
 
			//　タイマー表示用UIテキストに時間を表示する
			if((int)seconds != (int)oldSeconds) {
				timerText.text = minute.ToString("00") + ":" + ((int) seconds).ToString("00");
			}
			oldSeconds = seconds;
		}


		//　制限時間以下になったらゲームオーバーパネルを表示する
		if(totalTime <= 0f) {
			GameOverPanel.SetActive(true);
        
		}
    }
}
