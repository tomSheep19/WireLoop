#pragma strict

import UnityEngine.SceneManagement;

function NewGame() {
	SceneManager.LoadScene(1);
//	SceneManager.LoadScene(2);	
		
//	SceneManager.UnloadSceneAsync(0);
}

function Settings() {
	SceneManager.LoadScene(3);

}

function About() {
	SceneManager.LoadScene(4);
}

function MainMemu() {
	SceneManager.LoadScene(0);
//	SceneManager.UnloadSceneAsync(2);

}


