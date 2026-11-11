using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SolderingQuiz : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI titleText;      // the question
    public TextMeshProUGUI feedbackText;   // "Correct!" / "Not quite..."

    [Header("Answer Buttons (in order A, B, C, D)")]
    // Set each button's picture by hand in the editor.
    // A = Soldering Iron, B = Holder, C = Fume Extractor, D = PCB Board
    public Button[] answerButtons = new Button[4];

    [Header("Navigation")]
    public GameObject nextButton;      // shown after answering
    public GameObject restartButton;   // shown on the results screen

    string[] questions = {
        "Which one is the soldering iron?",
        "Which one is the soldering iron holder?",
        "Which one is the fume extractor?",
        "Which one is the PCB board?"
    };

    // Index of the correct button for each question (0 = A, 1 = B, 2 = C, 3 = D)
    int[] correctAnswer = { 0, 1, 2, 3 };

    string[] letters = { "A", "B", "C", "D" };

    int index = 0;
    int score = 0;
    bool answered = false;

    void Start()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            int choice = i; // copy for the lambda
            if (answerButtons[i] != null)
                answerButtons[i].onClick.AddListener(() => Answer(choice));
        }

        StartQuiz();
    }

    // Hook to the Restart button's OnClick.
    public void StartQuiz()
    {
        score = 0;
        SetAnswersVisible(true);
        ShowQuestion(0);
    }

    // Hook to the Next button's OnClick.
    public void Next()
    {
        if (index < questions.Length - 1) ShowQuestion(index + 1);
        else ShowResults();
    }

    void ShowQuestion(int i)
    {
        index = i;
        answered = false;

        titleText.text = questions[index];
        feedbackText.text = "";

        foreach (Button b in answerButtons) b.interactable = true;
        if (nextButton != null) nextButton.SetActive(false);
        if (restartButton != null) restartButton.SetActive(false);
    }

    void Answer(int choice)
    {
        if (answered) return;
        answered = true;

        if (choice == correctAnswer[index])
        {
            score++;
            feedbackText.text = "Correct!";
        }
        else
        {
            feedbackText.text = "Not quite. The answer is " + letters[correctAnswer[index]] + ".";
        }

        foreach (Button b in answerButtons) b.interactable = false;
        if (nextButton != null) nextButton.SetActive(true);
    }

    void ShowResults()
    {
        titleText.text = "Quiz Complete!";
        feedbackText.text = "You got " + score + " out of " + questions.Length + " correct.";

        SetAnswersVisible(false);
        if (nextButton != null) nextButton.SetActive(false);
        if (restartButton != null) restartButton.SetActive(true);
    }

    void SetAnswersVisible(bool visible)
    {
        foreach (Button b in answerButtons) b.gameObject.SetActive(visible);
    }
}