using TMPro;
using UnityEngine;

public class CardUI : MonoBehaviour
{
    // attributes

    [SerializeField] protected TMP_Text strength;
    [SerializeField] protected TMP_Text defense;
    [SerializeField] protected TMP_Text stamina;
    [SerializeField] protected TMP_Text agility;

    [SerializeField] protected TMP_Text hp;
    [SerializeField] protected TMP_Text price;

    public TextAsset jsonFile;

    // Start is called before the first frame update
    private void Start()
    {
        // foreach (CardData card in json.cards.Where(card => card.name == ))

        AddAttributes();
        AddHPPrice();
    }

    protected void AddAttributes()
    {
        // strength.text = "strength " + card.strength;
        // defense.text = "defense " + card.defense;
        // stamina.text = "stamina " + card.stamina;
        // agility.text = "agility " + card.agility;
    }

    private void AddHPPrice()
    {
        // hp.text = "HP " + card.HP;
        // price.text = "price " + card.Price;
    }

    public static void AddCard(CardData card, RectTransform panel, GameObject prefab)
    {
        GameObject goCard = (GameObject)Instantiate(prefab);

        TMP_Text[] texts = goCard.GetComponentsInChildren<TMP_Text>();

        texts[0].text = $"{card.color} dragon";

        texts[1].text = $"strength {card.strength}";
        texts[2].text = $"defense {card.defense}";
        texts[3].text = $"stamina {card.stamina}";
        texts[4].text = $"agility {card.agility}";

        texts[5].text = $"HP {card.HP}";
        texts[6].text = "price " + Mathf.Round(card.Price * Shop.conversionFactor);
        texts[7].text = $"level {card.level}";

        // var buttonComponent = goButton.GetComponent<Button>();
        //buttonComponent.onClick.AddListener(OnButtonClick);

        goCard.transform.SetParent(panel.transform, false);
    }

    // Update is called once per frame
    private void Update()
    {
    }

    [System.Serializable]
    public class Cards
    {
        public CardData[] cards;
    }

    [System.Serializable]
    public class CardData
    {
        public string name;
        public int strength;
        public int defense;
        public int stamina;
        public int agility;
        public int HP;
        public int Price;
        public int level;
        public string color;
    }
}