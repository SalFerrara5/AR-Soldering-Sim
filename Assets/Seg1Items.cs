using UnityEngine;
using TMPro;

public class SolderingQuiz : MonoBehaviour
{
    public TextMeshProUGUI Questions;
    public TextMeshProUGUI ShowAnswers;   // optional: running score

    // Question order: fume extractor, soldering iron, PCB board, holder
    // Letters: A = iron, B = holder, C = fume extractor, D = PCB board
    string[] questions = {
        "Which one is the fume extractor?",
        "Which physical asset is the soldering iron?",
        "Which one is the PCB board?",
        "Which physical asset is the soldering iron holder?"
    };

    // Correct answers in order: C, A, D, B
    string[] key = { "C", "A", "D", "B" };

    int question_num = -1;
    int correct = 0;

    void Start()
    {
        if (ShowAnswers != null) ShowAnswers.text = "0";
        NextQuestion();
    }

    // Hook each button's OnClick to this, passing "A", "B", "C" or "D".
    public void UpdateQuestionText(string AnswerText)
    {
        Debug.Log("Button pressed: " + AnswerText);

        if (question_num >= 0 && question_num < questions.Length)
        {
            if (AnswerText == key[question_num])
            {
                correct++;
                if (ShowAnswers != null) ShowAnswers.text = correct.ToString();
            }
        }
        NextQuestion();
    }

    // Right-click the component header while in Play mode to use these.
    [ContextMenu("Test Press A")]
    void TestPressA() { UpdateQuestionText("A"); }

    [ContextMenu("Test Press B")]
    void TestPressB() { UpdateQuestionText("B"); }

    [ContextMenu("Test Press C")]
    void TestPressC() { UpdateQuestionText("C"); }

    [ContextMenu("Test Press D")]
    void TestPressD() { UpdateQuestionText("D"); }

    void NextQuestion()
    {
        question_num++;

        if (question_num >= questions.Length)
        {
            Questions.text = "Quiz complete! Score: " + correct + "/" + questions.Length;
            return;
        }

        Questions.text = questions[question_num];
    }
}