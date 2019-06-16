using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class NumberWizard : MonoBehaviour
{
    [SerializeField] public int max;
    [SerializeField] public int min;
    [SerializeField] public TextMeshProUGUI guessText;

    private int guess;
    private static string winningNumber;
    private int[] maxMin;

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex.Equals(2))
            UpdateWinningNumber();
        else
            StartGame();
    }

    private void UpdateWinningNumber()
    {
        guessText.text = winningNumber;
    }

    private void StartGame()
    {
        maxMin = new int[2] { min, max };
        UpdateGuess();
    }

    public void OnPressHigher()
    {
        min = guess + 1;
        UpdateGuess();
    }

    public void OnPressLower()
    {
        max = guess - 1;
        UpdateGuess();
    }

    private void UpdateGuess()
    {
        if (min == 0) min = 1;
        if (max == 0) max = 1;

        if (min == max)
        {
            min = maxMin[0];
            max = maxMin[1];
        }

        guess = Random.Range(min, max + 1);
        UpdateGuessText();
    }

    private void UpdateGuessText()
    {
        string guessS = guess.ToString();
        guessText.text = guessS;
        winningNumber = guessS;
    }
}
