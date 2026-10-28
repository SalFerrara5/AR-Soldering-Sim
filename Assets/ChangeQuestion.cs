using UnityEngine;
using TMPro;
public class ChangeQuestion : MonoBehaviour
{
    public TextMeshProUGUI Questions;
    public TextMeshProUGUI AnswersA;
    public TextMeshProUGUI AnswersB;
    public TextMeshProUGUI AnswersC;
    public TextMeshProUGUI AnswersD;
    public TextMeshProUGUI ShowAnswers;
    string[] questions = {
                            "What temperature is generally appropriate for soldering typical through-hole electronic components with leaded solder?",
                            "When soldering a component lead to a PCB pad, which parts should be heated?",
                            "Where should solder be applied during a proper solder joint?",
                            "What is the primary purpose of flux when soldering?",
                            "What should a properly soldered joint generally look like?",
                            "What is the most likely result of using too much solder on a PCB?",
                            "What is a solder bridge?",
                            "Why should the soldering iron tip be properly tinned?",
                            "What should you do if the solder does not flow properly onto the component and pad?",
                            "Why should a solder joint be allowed to cool without being disturbed?",
                            "What is a 'cold solder joint' most commonly caused by?",
                            "What should you do before soldering a component onto a PCB?",
                            "Why is it important not to keep the soldering iron on a component or PCB pad for too long?",
                            "What is the safest place to put a soldering iron when it is not being used?",
                            "What is the purpose of inspecting a solder joint after soldering?"
                        };
    string[,] answers = {
                            { "200°F (93°C)", "350°F (177°C)", "600°F (316°C)", "900°F (482°C)" },
                            { "Only the solder", "Only the component lead", "Both the component lead and the PCB pad", "The PCB surrounding the pad" },
                            { "Directly to the tip of the iron", "To the heated component lead and pad", "To the PCB several millimeters away from the joint", "Before the iron touches the joint" },
                            { "To make the solder harder", "To cool the component", "To remove oxides and help solder flow and bond", "To increase the electrical resistance of the joint" },
                            { "Dull, cracked, and uneven", "Smooth and evenly wetted around the connection", "A large ball of solder covering the entire pad", "Completely flat with no visible solder" },
                            { "The joint will always be stronger", "The solder will become electrically insulating", "It can create solder bridges or unintended connections", "The component will automatically disconnect" },
                            { "A protective coating placed over a PCB", "An unintended connection of solder between two conductive points", "A type of soldering iron stand", "A wire used to connect two boards" },
                            { "To make the iron heavier", "To prevent the iron from heating up too quickly", "To improve heat transfer and protect the tip from oxidation", "To prevent solder from sticking to the tip" },
                            { "Add more solder to the iron tip", "Increase the iron temperature as high as possible", "Make sure the joint is being heated properly and that the surfaces are clean", "Blow on the joint to cool it" },
                            { "Moving it can cause a weak or cracked joint", "It makes the solder melt faster", "It prevents the PCB from conducting electricity", "It increases the solder's melting temperature" },
                            { "Using too much flux", "Insufficient heating or movement of the joint while the solder is solidifying", "Using a clean soldering iron", "Using too little electricity in the circuit" },
                            { "Verify the component's location and orientation", "Apply solder to every pad on the PCB", "Heat the component for several seconds", "Remove all solder from the PCB" },
                            { "It can damage the component, pad, or PCB", "It makes solder impossible to remove", "It causes the solder to become magnetic", "It makes the solder electrically insulating" },
                            { "On the workbench", "On the PCB", "In an appropriate soldering iron stand", "On a piece of paper" },
                            { "To make sure the solder is the correct color", "To verify that the joint is properly formed and there are no defects or unintended connections", "To determine how hot the iron was", "To remove all visible solder" }
                         };
    string[] key = {
                        "C",
                        "C",
                        "B",
                        "C",
                        "B",
                        "C",
                        "B",
                        "C",
                        "C",
                        "A",
                        "B",
                        "A",
                        "A",
                        "C",
                        "B"
                    };
    int question_num = 0;
    int correct = 0;
    public void UpdateQuestionText(string AnswerText)
    {
        if (question_num < questions.Length)
        {   
            if (AnswerText == key[question_num])
            {
                correct += 1;
                ShowAnswers.text = correct.ToString();
            }
            Questions.text = questions[question_num];
            
            AnswersA.text = "A: " + answers[question_num,0];
            AnswersB.text = "B: " + answers[question_num, 1];
            AnswersC.text = "C: " + answers[question_num, 2];
            AnswersD.text = "D: " + answers[question_num, 3];
            
            question_num += 1;
        }
        Debug.Log(question_num);
    }
}
