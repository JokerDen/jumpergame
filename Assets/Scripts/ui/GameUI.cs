using System;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public StartUI titleScreen;
    public FailUI failScreen;
    public GameplayUI gameplay;

    public void ShowIntro(Action callback)
    {
        gameplay.Hide();
        failScreen.Hide();
        titleScreen.ShowIntro(callback);
    }

    public void ShowTitle()
    {
        gameplay.Hide();
        failScreen.Hide();
        titleScreen.Show();
    }

    public void ShowGameplay()
    {
        gameplay.Show();
        titleScreen.Hide();
        failScreen.Hide();
    }
}
