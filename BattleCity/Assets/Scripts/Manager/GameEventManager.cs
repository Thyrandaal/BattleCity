using System;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager
{
#region Singleton
    static GameEventManager instance;
    public static GameEventManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new GameEventManager();
            }
            return instance;
        }
    }

    GameEventManager() { }
#endregion

    public Action OnEagleDie;

    public void DispatchEagleDie()
    {
        if(OnEagleDie != null)
        {
            OnEagleDie();
        }
    }
}
