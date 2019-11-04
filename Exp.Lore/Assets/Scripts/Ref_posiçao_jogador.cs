using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ref_posiçao_jogador : MonoBehaviour
{
	#region Singleton

	public static Ref_posiçao_jogador instance;

	 void Awake()
	 {
		instance = this;
	 }

	#endregion

	public GameObject player;

	public void MatarPlayer ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
