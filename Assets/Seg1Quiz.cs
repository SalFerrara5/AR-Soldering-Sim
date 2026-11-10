using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeQuestion2 : MonoBehaviour
{
    public TextMeshProUGUI Questions;
    public TextMeshProUGUI AnswersA;
    public TextMeshProUGUI AnswersB;
    public TextMeshProUGUI AnswersC;
    public TextMeshProUGUI AnswersD;
    public TextMeshProUGUI ShowAnswers;

    // Optional: a separate text object for long explanations.
    // If left empty, details are shown under the question in smaller text.
    public TextMeshProUGUI DetailsText;

    // Top-level button objects for C and D (auto-found if left empty).
    public GameObject ButtonC;
    public GameObject ButtonD;

    string[] questions = {
        "Why should you solder in a well-ventilated area and with a fume extractor?",
        "What is an acceptable way to put down the soldering iron?",
        "Which are the proper PPE?",
        "T/F: The Soldering Iron can be left turned on if it is safely put in the holder.",
        "T/F: Solder with lead or lead oxide are allowed at RPI, but there are specific requirements to use it.",
        "Burn Safety"   // short title; the long text lives in details below
    };

    // One entry per question; "" means no extra details.
    string[] details = {
        "", "", "", "", "",
        "If you get burned while soldering: turn off the iron, put it safely in the holder, " +
        "tell the instructor, and call pubsafe or go to the health center as needed.\n" +
        "Also fill out an EHS incident form:\nehs.rpi.edu/form/ehs-incident-report"
    };

    string[][] answers = {
        new[] { "Flux Smoke can irritate your lungs and eyes", "It helps the solder to cool", "It prevents the iron from rusting", "You only need ventilation for lead solder" },
        new[] { "Lean it against the project board", "keep holding it", "lay it on the edge of a workbench", "Put it in the proper stand or holder" },
        new[] { "Long pants, safety glasses", "Long sleeves, Long pants, Safety Glasses", "Long Sleeves, Long Pants, Welding Helmet, Heat-resistant gloves", "Long Pants, Safety Glasses, Latex Gloves" },
        new[] { "T", "F" },
        new[] { "T", "F" },
        new[] { "I acknowledge", "I want to review the material" }
    };

    // For T/F questions: "A" = True, "B" = False.
    string[] key = { "A", "D", "B", "B", "A", "A" };

    int question_num = -1;
    int correct = 0;

    void Start()
    {
        // Auto-find the buttons if they weren't assigned in the Inspector.
        if (ButtonC == null && AnswersC != null)
        {
            Button b = AnswersC.GetComponentInParent<Button>(true);
            if (b != null) ButtonC = b.gameObject;
        }
        if (ButtonD == null && AnswersD != null)
        {
            Button b = AnswersD.GetComponentInParent<Button>(true);
            if (b != null) ButtonD = b.gameObject;
        }
        if (ButtonC == null || ButtonD == null)
            Debug.LogWarning("ButtonC/ButtonD not found. Assign them in the Inspector so they can be hidden.");

        // Shrink long question text to fit instead of overflowing.
        Questions.enableAutoSizing = true;
        Questions.fontSizeMin = 18;
        Questions.fontSizeMax = Questions.fontSize;
        Questions.overflowMode = TextOverflowModes.Truncate;

        if (ShowAnswers != null) ShowAnswers.text = "0";
        NextQuestion();
    }

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

    [ContextMenu("Test Press A")]
    void TestPressA()
    {
        UpdateQuestionText("A");
    }

    void SetCDVisible(bool visible)
    {
        if (ButtonC != null) ButtonC.SetActive(visible);
        if (ButtonD != null) ButtonD.SetActive(visible);
    }

    void NextQuestion()
    {
        question_num++;

        // Quiz finished.
        if (question_num >= questions.Length)
        {
            // Last question is an acknowledgment, so it isn't counted in the total.
            Questions.text = "Quiz complete! Score: " + correct + "/" + (questions.Length - 1);
            if (DetailsText != null) DetailsText.text = "";
            AnswersA.text = "";
            AnswersB.text = "";
            AnswersC.text = "";
            AnswersD.text = "";
            SetCDVisible(false);
            return;
        }

        string[] a = answers[question_num];
        string detail = details[question_num];

        // Show title, plus details either in their own text object or under the title.
        if (DetailsText != null)
        {
            Questions.text = questions[question_num];
            DetailsText.text = detail;
        }
        else
        {
            Questions.text = string.IsNullOrEmpty(detail)
                ? questions[question_num]
                : questions[question_num] + "\n<size=60%>" + detail + "</size>";
        }

        AnswersA.text = "A: " + a[0];
        AnswersB.text = "B: " + a[1];

        // Only show C and D if this question has them (hidden on T/F and acknowledgment).
        bool hasCD = a.Length > 2;
        SetCDVisible(hasCD);

        AnswersC.text = hasCD ? "C: " + a[2] : "";
        AnswersD.text = hasCD ? "D: " + a[3] : "";
    }
}