using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private TextAsset jsonFile;

    [SerializeField]
    private TextAsset jsonMagicFile;

    public GameObject cardPrefab;
    public GameObject cardMagicPrefab;

    public GameObject panelCards;
    public GameObject panelMagicCards;

    public RectTransform panel;
    public RectTransform panelMagic;

    [SerializeField] private TMP_Text currencyRate;

    public static float conversionFactor;

    // private string[] colors = { "white", "magnolia", "snow", "vanilla", "yellow", "amber", "gold", "jasmine", "azure", "sapphire", "blue", "indigo", "turquoise", "brown", "almond", "bronze", "chocolate", "copper", "rust", "teal", "green", "emerald", "jade", "malachite", "violet", "purple", "orange", "coral", "pink", "raspberry", "amethyst", "red", "scarlet", "gray", "silver", "platinum", "black" };

    // Start is called before the first frame update
    private void Start()
    {
        conversionFactor = Random.Range(3f, 4f);
        print(conversionFactor);
        float conversionTemp = (float)Mathf.Round(conversionFactor * 100f) / 100f;
        currencyRate.text = "currency rate " + conversionTemp.ToString();

        AddCards();
        AddMagicCards();
    }

    private void OnButtonClick()
    {
    }

    private void AddCards()
    {
        CardUI.Cards json = JsonUtility.FromJson<CardUI.Cards>(jsonFile.text);

        foreach (CardUI.CardData card in json.cards)
        {
            CardUI.AddCard(card, panel, cardPrefab);
        }
    }

    private void AddMagicCards()
    {
        CardMagicUI.CardsMagic json = JsonUtility.FromJson<CardMagicUI.CardsMagic>(jsonMagicFile.text);

        foreach (CardMagicUI.CardMagicData card in json.cardsMagic)
        {
            CardMagicUI.AddCard(card, panelMagic, cardMagicPrefab);
        }
    }

    public void ShowPanelCards()
    {
        panelCards.SetActive(true);
        panelMagicCards.SetActive(false);
    }

    public void ShowPanelMagicCards()
    {
        panelMagicCards.SetActive(true);
        panelCards.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}