using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//操作説明シーンからゲームシーンへ移行
public class SceneManagement2 : MonoBehaviour {

	// Update is called once per frame
	void Update() {

		if (Input.GetKeyDown(KeyCode.Space)) {
			SceneManager.LoadScene("GameScene");
		}
	}
}
