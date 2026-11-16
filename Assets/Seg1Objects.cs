using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SolderingGallery : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI subtitleText;
    public Image pictureImage;

    [Tooltip("Optional: small text like 1/8")]
    public TextMeshProUGUI counterText;

    [Header("Buttons (optional, hidden at the ends)")]
    public GameObject backButton;
    public GameObject nextButton;

    [Header("Options")]
    public bool loop = false;

    [Header("Pictures (same order as the list below)")]
    // 0 Solder Wire, 1 Soldering Iron, 2 Iron Holder, 3 Flux,
    // 4 Fume Extractor, 5 Tip Cleaner, 6 PCB Board, 7 Components
    public Sprite[] pictures = new Sprite[8];

    string[] titles = {
        "Solder Wire",
        "Soldering Iron",
        "Soldering Iron Holder",
        "Flux",
        "Fume Extractor / Fan",
        "Wet Sponge / Brass Wool Tip Cleaner",
        "PCB Board",
        "Resistor, Capacitor, LED"
    };

    string[] descriptions = {
        "Metal alloy that melts to make an electrical or mechanical joint",
        "Device that heats solder to use",
        "Stand/holder to rest the hot iron",
        "Cleans metal surface and helps solder bond",
        "Pulls flux smoke away from your face",
        "Item to clean solder tip",
        "Printed Circuit Board is the electrical board that you are soldering",
        "Electronic components that will be soldered to the PCB board"
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