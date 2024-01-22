using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action OnKeyEnter;

    public void KeyEnter()
    {
        if (OnKeyEnter != null)
        {
            OnKeyEnter();
        }
    }

    public event Action OnGameWon;

    public void GameWon()
    {
        if (OnGameWon != null)
        {
            OnGameWon();
        }
    }

    public event Action<SoundTypes> OnSoundPlayed;

    public void SoundPlayed(SoundTypes sound)
    {
        if (OnSoundPlayed != null)
        {
            OnSoundPlayed(sound);
        }
    }
}