using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject loadingscreen; // un Go loadingscreen
    public Slider slider;// un objet slider pour le loading bar
    public void LoadLevel(int sceneIndex) // pour loader le niveau
    {
        StartCoroutine(LoadAsync(sceneIndex)); // delay de temps 
    }
    IEnumerator LoadAsync(int sceneIndex) // fonction pour deplacer le slider 
    {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingscreen.SetActive(true);
        while(!operation.isDone)
            {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
                yield return null;
            }
    }
}
