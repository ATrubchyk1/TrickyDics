using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScreen : MonoBehaviour
{
    [UsedImplicitly]
    public void StartGame() // Вызываем при нажатии на кнопку старт игры.
    {
        SceneManager.LoadSceneAsync(GlobalConstants.GAME_SCENE);
    }
}
