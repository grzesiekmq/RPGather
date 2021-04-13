using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private TMP_Text lvlText;
    [SerializeField] private TMP_Text lvlNumber;
    [SerializeField] private GameObject lvlPopup;
    [SerializeField] private TMP_Text lvlPopupText;

    [SerializeField] private TMP_Text expText;

    [SerializeField] private TMP_Text money;

    private int[] lvlupThresholds = {256,
512,
1152,
2048,
3200,
4608,
6272,
8192,
10368,
12800,
15488,
18432,
21632,
25088,
28800,
32768,
36992,
41472,
46208
};

    // Start is called before the first frame update
    private void Start()
    {
        DisplayGold();
        LevelUp();
    }

    private void DisplayGold()
    {
        money.text = PlayerState.money.ToString();
    }

    public static void UpdateGold(int money)
    {
        PlayerState.money += money;
    }

    public static void UpdateExp(int exp)
    {
        PlayerState.exp += exp;
    }

    private void LevelUp()
    {
        foreach (int lvl in lvlupThresholds)
        {
            if (PlayerState.exp > lvl) NextLevel();
        }
    }

    private void NextLevel()
    {
        PlayerState.level++;
        lvlPopup.SetActive(true);
        lvlNumber.text = PlayerState.level.ToString();
        lvlPopupText.text = "lvl up!";
    }

    public void OnOk()
    {
        lvlPopup.SetActive(false);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        lvlText.text = $"lvl {PlayerState.level}";
        expText.text = $"exp {PlayerState.exp}/1000";

        money.text = PlayerState.money.ToString();
    }
}