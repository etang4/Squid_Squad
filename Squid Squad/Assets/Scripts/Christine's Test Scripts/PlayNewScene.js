#pragma strict

function Start () {

}

function Update () {

}
static function EditorPlaying() 
{
	if(EditorApplication.isPlaying) 
	{
		//PlayerPrefs.GetString("CartCharacter");
    
		var sceneName : String = EditorApplication.currentScene;
		var path : String [] = sceneName.Split(char.Parse("/"));
		
		path[path.Length -1] = "Temp_" + path[path.Length-1];
		var tempScene = String.Join("/",path);

		EditorApplication.SaveScene(tempScene);
		
		EditorApplication.isPaused = false;
		EditorApplication.isPlaying = false;
		
		FileUtil.DeleteFileOrDirectory(EditorApplication.currentScene);
		FileUtil.MoveFileOrDirectory(tempScene, sceneName);
		FileUtil.DeleteFileOrDirectory(tempScene);
		
		EditorApplication.OpenScene(sceneName);
	}
}