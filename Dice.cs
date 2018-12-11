
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour {

	public Text score;
	public Text highScore;

	void Start ()
	{
		highScore.text = PlayerPrefs.GetInt("HighScore",0).ToString();
	}

	public void RollDice ()
	{
		int number = Random.Range(1,7 );
		score.text = number.ToString();

		if (number > PlayerPrefs.GetInt("HighScore",0));
		{
			PlayerPrefs.SetInt("HighScore",number);
			highScore.text= number.ToString(); 
		}
	}
public void Reset ()
{
	PlayerPrefs.DeleteAll();
	highScore.text="0";
}
}