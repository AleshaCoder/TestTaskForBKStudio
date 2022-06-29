using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    private void Awake() => DontDestroyOnLoad(gameObject);
    public void LoadInitial() => SceneManager.LoadScene(Scenes.Initial);
    public void LoadCalculator() => SceneManager.LoadScene(Scenes.Calculator);
    public void LoadGame() => SceneManager.LoadScene(Scenes.Game);
    public void LoadImages() => SceneManager.LoadScene(Scenes.Images);
    public void LoadUI() => SceneManager.LoadScene(Scenes.UI);
}
