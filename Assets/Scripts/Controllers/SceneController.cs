using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;


public class SceneController : MonoBehaviour
{
    [Header("Animate Scene Transitions")]
    [SerializeField] private float transitionDelay = 1f;
    [SerializeField] private Animator transitionAnimator;

    private const string ANIM_TRIGGER = "Start";

    void Start()
    {
        UnlockCursor();
    }

    public void MainMenu(bool animate = false) => ChangeScene(SceneNames.MAIN_MENU, animate);
    public void Level1(bool animate = false) => ChangeScene(SceneNames.Level1, animate);

    public void Level2(bool animate = false) => ChangeScene(SceneNames.Level2, animate);
    public void Level3(bool animate = false) => ChangeScene(SceneNames.Level3, animate);

    public void ChangeScene(string name, bool animate = false)
    {
        if (animate)
        {
            StartCoroutine(SceneTransition(name));
        }
        else
        {
            SceneManager.LoadSceneAsync(name);
        }
    }

    private IEnumerator SceneTransition(string sceneName)
    {
        if (transitionAnimator)
        {
            // Show an animation
            transitionAnimator.SetTrigger(ANIM_TRIGGER);
        }

        yield return new WaitForSeconds(transitionDelay);

        SceneManager.LoadSceneAsync(sceneName);
    }

    private void UnlockCursor()
    {
        // Make sure the cursor isn't locked if coming from a game scene (FPS controller locks the cursor)
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
