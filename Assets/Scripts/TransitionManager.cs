using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class TransitionManager : MonoBehaviour
{
    public static TransitionManager Instance;

    [SerializeField] private RawImage transitionImage;
    [SerializeField] private float dissolveDuration = 1f;

    private Texture2D screenshot;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void DissolveToScene(string sceneName)
    {
        StartCoroutine(Dissolve(sceneName));
    }

    private IEnumerator Dissolve(string sceneName)
    {
        yield return new WaitForEndOfFrame();

        screenshot = ScreenCapture.CaptureScreenshotAsTexture();

        transitionImage.texture = screenshot;
        transitionImage.color = Color.white;
        transitionImage.gameObject.SetActive(true);

        AsyncOperation operation =
            SceneManager.LoadSceneAsync(sceneName);

        operation.allowSceneActivation = false;

        while (operation.progress < 0.9f)
            yield return null;

        operation.allowSceneActivation = true;

        yield return null;
        yield return new WaitForEndOfFrame();

        float timer = 0f;

        while (timer < dissolveDuration)
        {
            timer += Time.deltaTime;

            float alpha =
                1f - Mathf.Clamp01(timer / dissolveDuration);

            Color color = transitionImage.color;
            color.a = alpha;
            transitionImage.color = color;

            yield return null;
        }

        transitionImage.gameObject.SetActive(false);

        Destroy(screenshot);
        screenshot = null;
    }
}