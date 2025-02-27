using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    protected GameManager gameManager;

    private void Awake() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.PrintSceneStack();
    }

    public void Back() {
        gameManager.LoadPreviousScene();
    }
}
