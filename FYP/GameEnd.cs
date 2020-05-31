﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public GameObject gameEndPanel;

    private void OnDestroy() {
        Time.timeScale = 0;
        gameEndPanel.SetActive(true);
    }
}
