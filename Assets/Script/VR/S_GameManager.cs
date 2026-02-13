using System.Collections.Generic;
using UnityEngine;

public class S_GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform spawnPointEnemy;
    [SerializeField] private List<GameObject> listEnemy;

    [Header("Inputs")]
    [SerializeField] private RSE_OnStartGame rseOnStartGame;
    [SerializeField] private RSE_OnRestartFight rseOnRestartFight;
    [SerializeField] private RSE_OnNextFight rseOnNextFight;
    [SerializeField] private RSE_OnReset rseOnReset;

    [Header("Outputs")]
    [SerializeField] private RSE_OnDisplayUI rseOnDisplayUI;
    [SerializeField] private RSE_OnDisplayGun rseOnDisplayGun;

    private GameObject currentEnemy = null;
    private int currentIndex = 0;

    private void OnEnable()
    {
        rseOnStartGame.Action += StartGame;
        rseOnRestartFight.Action += RestartFight;
        rseOnNextFight.Action += NextFight;
        rseOnReset.Action += ResetGame;
    }

    private void OnDisable()
    {
        rseOnStartGame.Action -= StartGame;
        rseOnRestartFight.Action -= RestartFight;
        rseOnNextFight.Action -= NextFight;
        rseOnReset.Action -= ResetGame;
    }

    private void StartGame()
    {
        rseOnDisplayUI.Call(true);
        rseOnDisplayGun.Call(true);

        if (currentEnemy != null) Destroy(currentEnemy);

        currentIndex = 0;

        currentEnemy = Instantiate(listEnemy[currentIndex], spawnPointEnemy.position, spawnPointEnemy.rotation);
    }

    private void RestartFight()
    {
        if (currentEnemy != null) Destroy(currentEnemy);

        currentEnemy = Instantiate(listEnemy[currentIndex], spawnPointEnemy.position, spawnPointEnemy.rotation);
    }

    private void NextFight()
    {
        if (currentEnemy != null) Destroy(currentEnemy);

        currentIndex = (currentIndex + 1) % listEnemy.Count;

        currentEnemy = Instantiate(listEnemy[currentIndex], spawnPointEnemy.position, spawnPointEnemy.rotation);
    }

    private void ResetGame()
    {
        if (currentEnemy != null) Destroy(currentEnemy);

        currentIndex = 0;

        currentEnemy = Instantiate(listEnemy[currentIndex], spawnPointEnemy.position, spawnPointEnemy.rotation);
    }
}