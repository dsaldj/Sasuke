using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//タイトルシーンから操作説明シーンへ遷移
public class SceneManagement: MonoBehaviour {

	// Update is called once per frame
	void Update() {

		if (Input.GetKeyDown(KeyCode.Space)) {
			SceneManager.LoadScene("Explanation");
		}
	}
}
