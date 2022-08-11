using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonStartGame : ButtonAction
{  
    public override void ButtonClick() => SceneManager.LoadScene(1);
}
