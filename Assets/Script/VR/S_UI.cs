using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_UI : MonoBehaviour
{
    //[Header("Settings")]

    [Header("References")]
    [SerializeField] private GameObject windowLeft;
    [SerializeField] private GameObject windowRight;
    [SerializeField] private GameObject windowCenter;
    [SerializeField] private TextMeshProUGUI textDrawSpeed;
    [SerializeField] private TextMeshProUGUI textReflex;
    [SerializeField] private TextMeshProUGUI textFinalScore;
    [SerializeField] private TextMeshProUGUI textDrawSpeedAverage;
    [SerializeField] private TextMeshProUGUI textReflexAverage;

    [Header("Input")]
    [SerializeField] private RSE_OnDisplayUI rseOnDisplayUI;

    //[Header("Output")]


    private bool isLoading = false;

    private void OnEnable()
    {
        rseOnDisplayUI.Action += DisplayUI;
    }

    private void OnDisable()
    {
        rseOnDisplayUI.Action -= DisplayUI;
    }

    private void Start()
    {
        isLoading = false;

        windowLeft.SetActive(false);
        windowRight.SetActive(false);
        windowCenter.SetActive(true);
    }

    private void DisplayUI(bool value)
    {
        windowLeft.SetActive(value);
        windowRight.SetActive(value);
        windowCenter.SetActive(!value);
    }

    public void QuitGame()
    {
        if (isLoading) return;

        isLoading = true;

        Application.Quit();
    }
}