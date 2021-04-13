using TMPro;
using UnityEngine;

public class CardMagicUI : CardUI
{
    [SerializeField] private TMP_Text magic;

    // Start is called before the first frame update
    private void Start()
    {
        // foreach (CardMagicData card in json.cards.Where(card => card.name == ))

        AddAttributes();
        AddHPPrice();
        // magic.text = "magic " + card.magic;
    }

    private void AddHPPrice()
    {
        // hp.text = "HP " + card.hp;
        // price.text = "price " + card.price;
    }

    public static void AddCard(CardMagicData card, RectTransform panel, GameObject prefab)
    {
        GameObject goCard = (GameObject)Instantiate(prefab);

        TMP_Text[] texts = goCard.GetComponentsInChildren<TMP_Text>();

        texts[0].text = $"{card.color} magic dragon";

        texts[1].text = $"strength {card.strength}";
        texts[2].text = $"defense {card.defense}";
        texts[3].text = $"stamina {card.stamina}";
        texts[4].text = $"agility {card.agility}";

        texts[5].text = $"HP {card.HP}";
        texts[6].text = "price " + Mathf.Round(card.Price * Shop.conversionFactor);
        texts[7].text = $"level {card.level}";
        texts[8].text = $"magic {card.magic}";

        // var buttonComponent = goButton.GetComponent<Button>();
        //buttonComponent.onClick.AddListener(OnButtonClick);

        goCard.transform.SetParent(panel.transform, false);
    }

    // Update is called once per frame
    private void Update()
    {
    }

    [System.Serializable]
    public class CardsMagic
    {
        public CardMagicData[] cardsMagic;
    }

    [System.Serializable]
    public class CardMagicData : CardData
    {
        public int magic;
    }
}