using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SolderingSafety : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI subtitleText;
    public Image pictureImage;

    [Tooltip("Optional: small text like 1/9")]
    public TextMeshProUGUI counterText;

    [Header("Buttons (optional, hidden at the ends)")]
    public GameObject backButton;
    public GameObject nextButton;

    [Header("Options")]
    public bool loop = false;

    [Header("Pictures (optional, same order as the list below)")]
    // 0 Heat Safety, 1 Setting Up, 2 Proper PPE, 3 Clear Work Area,
    // 4 Proper Ventilation, 5 Use Lead-Free Solder, 6 Putting It Away,
    // 7 Cleanup and Waste, 8 More Information
    public Sprite[] pictures = new Sprite[9];

    string[] titles = {
        "Heat Safety",
        "Setting Up",
        "Proper PPE",
        "Clear Work Area",
        "Proper Ventilation",
        "Use Lead-Free Solder",
        "Putting It Away",
        "Cleanup and Waste",
        "More Information"
    };

    string[] descriptions = {
        "Lead-free solder tips reach 315-345°C (600-650°F). The red area on the iron is the hot part. Never touch it or the solder.",
        "Make sure the electronics you're working on are unplugged and powered down. Check that power cords aren't frayed or in your way.",
        "Wear long sleeves, long pants, and eye protection. Tie back long hair and remove necklaces and loose items.",
        "Remove anything flammable from the area. No food or drink in the soldering area.",
        "Turn on the fan or fume extractor before you begin soldering.",
        "Solder with lead or lead oxide is not allowed at RPI. Only use lead-free solder.",
        "Turn off the iron when you're not using it. Let it cool fully, then store it safely in its holder. Keep the cord clear of the hot tip.",
        "Soldering waste is regulated and has specific disposal requirements. Wash your hands when you're done.",
        "Visit ehs.rpi.edu or email EHS@rpi.edu."
    };

    int index = 0;

    void Start()
    {
        Show(0);
    }

    // Hook these to the buttons' OnClick.
    public void Next()
    {
        if (index < titles.Length - 1) Show(index + 1);
        else if (loop) Show(0);
    }

    public void Back()
    {
        if (index > 0) Show(index - 1);
        else if (loop) Show(titles.Length - 1);
    }

    void Show(int i)
    {
        index = i;

        if (titleText != null) titleText.text = titles[index];
        if (subtitleText != null) subtitleText.text = descriptions[index];

        if (pictureImage != null)
        {
            Sprite s = (pictures != null && index < pictures.Length) ? pictures[index] : null;
            pictureImage.sprite = s;
            pictureImage.gameObject.SetActive(s != null);
        }

        if (counterText != null)
            counterText.text = (index + 1) + "/" + titles.Length;

        if (backButton != null) backButton.SetActive(loop || index > 0);
        if (nextButton != null) nextButton.SetActive(loop || index < titles.Length - 1);
    }

    [ContextMenu("Test Next")]
    void TestNext() { Next(); }
}