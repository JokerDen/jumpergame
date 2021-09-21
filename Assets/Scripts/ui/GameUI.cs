using System;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public StartUI titleScreen;
    public FailUI failScreen;

    public void ShowStartGameplay(Action callback)
    {
        failScreen.Hide();
        titleScreen.ShowStart(callback);
    }

    public void ShowTitle()
    {
        failScreen.Hide();
        titleScreen.Show();
    }
}
