
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Segment2Walkthrough : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI subtitleText;
    public Image pictureImage;

    [Header("Navigation Buttons")]
    public GameObject backButton;
    public GameObject nextButton;

    [Header("Slide Images - Assign in Inspector")]
    public Sprite[] pictures = new Sprite[6];

    private int index = 0;

    private string[] titles =
    {
        "Identify the LED Components",
        "Place the LED",
        "Prepare the Soldering Iron",
        "Heat the LED Lead and PCB Pad",
        "Apply Solder to the Joint",
        "Inspect the Solder Joint"
    };

    private string[] descriptions =
    {
        "Identify the LED's longer positive lead and shorter negative lead. Match the polarity markings on the PCB.",

        "Insert the LED leads into the correct PCB holes, ensuring the polarity matches the board markings.",

        "Heat the soldering iron to approximately 316°C (600°F). Hold it by the insulated handle.",

        "Touch the iron tip to both the LED lead and PCB pad. Allow both surfaces to heat.",

        "Feed solder to the heated lead and pad, not directly onto the iron tip. Let solder flow around the joint.",

        "Remove the iron and let the joint cool. Check for a smooth, secure connection without solder bridges."
    };

    void Start()
    {
        ShowSlide(0);
    }

    public void Next()
    {
        if (index < titles.Length - 1)
        {
            ShowSlide(index + 1);
        }
    }

    public void Back()
    {
        if (index > 0)
        {
            ShowSlide(index - 1);
        }
    }

    void ShowSlide(int slideIndex)
    {
        index = slideIndex;

        if (titleText != null)
            titleText.text = titles[index];

        if (subtitleText != null)
            subtitleText.text = descriptions[index];

        if (pictureImage != null)
        {
            Sprite currentSprite =
                index < pictures.Length
                ? pictures[index]
                : null;

            pictureImage.sprite = currentSprite;
            pictureImage.gameObject.SetActive(
                currentSprite != null
            );
        }

        if (backButton != null)
            backButton.SetActive(index > 0);

        if (nextButton != null)
            nextButton.SetActive(
                index < titles.Length - 1
            );
    }
}
