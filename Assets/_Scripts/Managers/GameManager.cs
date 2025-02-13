using System;
using UnityEngine;

public class GameManager: Singleton<GameManager> {
    public int score = 0;
    
    private void Start() {
        score = 0;
    }
}