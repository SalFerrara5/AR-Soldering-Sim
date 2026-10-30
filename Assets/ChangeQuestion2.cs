using UnityEngine;
using TMPro;

public class ChangeQuestion2 : MonoBehaviour
{
    public TextMeshProUGUI Questions;
    public TextMeshProUGUI AnswersA;
    public TextMeshProUGUI AnswersB;
    public TextMeshProUGUI AnswersC;
    public TextMeshProUGUI AnswersD;
    public TextMeshProUGUI ShowAnswers;

    // Assign the top-level PrimaryButton objects for C and D
    // so they can be hidden on True/False questions.
    public GameObject ButtonC;
    public GameObject ButtonD;

    string[] questions = {
        "Why should you solder in a well-ventilated area and with a fume extractor?",
        "What is an acceptable way to put down the soldering iron?",
        "Which are the proper PPE?",
        "T/F: The Soldering Iron can be left turned on if it is safely put in the holder.",
        "T/F: Solder with lead or lead oxide are allowed at RPI, but there are specific requirements to use it.",
        "If you get burned while soldering, you should turn off the iron, put it safely in the holder, tell the instructor, call pubsafe or go to health center as needed. Also fill out an EHS incident form: https://ehs.rpi.edu/form/ehs-incident-report."
    };

    // Jagged array: each question can have a different number of answers.
    string[][] answers = {
        new[] { "Flux Smoke can irritate your lungs and eyes", "It helps the solder to cool", "It prevents the iron from rusting", "You only need ventilation for lead solder" },
        new[] { "Lean it against the project board", "keep holding it", "lay it on the edge of a workbench", "Put it in the proper stand or holder" },
        new[] { "Long pants, safety glasses", "Long sleeves, Long pants, Safety Glasses", "Long Sleeves, Long Pants, Welding Helmet, Heat-resistant gloves", "Long Pants, Safety Glasses, Latex Gloves" },
        new[] { "T", "F" },
        new[] { "T", "F" },
        new[] { "I acknowledge", "I want to review the material" }
    };

    // One entry per question (must be the same length as questions).
    // For T/F questions: "A" = True, "B" = False.
    string[] key = { "A", "D", "B", "B", "A", "A" };

    int question_num = -1;   // -1 = quiz has not started yet
    int correct = 0;

    void Start()
    {
        if (ShowAnswers != null) ShowAnswers.text = "0";
        NextQuestion();
    }

    // Hook your A/B/C/D buttons to this, passing "A", "B", "C" or "D".
    public void UpdateQuestionText(string AnswerText)
    {
        Debug.Log("Button pressed: " + AnswerText);

        // Grade the question currently on screen.
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

    // Right-click the component header (or use the three dots) and choose
    // "Test Press A" in Play mode to test without clicking a button.
    [ContextMenu("Test Press A")]
    void TestPressA()
    {
        UpdateQuestionText("A");
    }

    void NextQuestion()
    {
        question_num++;

        // Quiz finished.
        if (question_num >= questions.Length)
        {
            // Last question is an acknowledgment, so it isn't counted in the total.
            Questions.text = "Quiz complete! Score: " + correct + "/" + (questions.Length - 1);
            AnswersA.text = "";
            AnswersB.text = "";
            AnswersC.text = "";
            AnswersD.text = "";
            if (ButtonC != null) ButtonC.SetActive(false);
            if (ButtonD != null) ButtonD.SetActive(false);
            return;
        }

        string[] a = answers[question_num];
        Questions.text = questions[question_num];

        AnswersA.text = "A: " + a[0];
        AnswersB.text = "B: " + a[1];

        // Only show C and D if this question has them.
        bool hasCD = a.Length > 2;
        if (ButtonC != null) ButtonC.SetActive(hasCD);
        if (ButtonD != null) ButtonD.SetActive(hasCD);

        AnswersC.text = hasCD ? "C: " + a[2] : "";
        AnswersD.text = hasCD ? "D: " + a[3] : "";
    }
}