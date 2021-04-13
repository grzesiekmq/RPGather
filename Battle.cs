using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    [SerializeField] private TMP_Text hpText;
    [SerializeField] private TMP_Text diffHpFoe;
    [SerializeField] private Slider slider;

    [SerializeField] private GameObject victory;

    [SerializeField] private Slider sliderOwner;

    private int hp;

    // Start is called before the first frame update
    private void Start()
    {
        hp = 500;
        slider.maxValue = 500;
    }

    public void OnAttack()
    {
        int randomDamage = Utils.RandomValue(min: 10, max: 20);
        TakeDamage(randomDamage);
        slider.value -= 10;

        sliderOwner.value -= randomDamage / 2;

        diffHpFoe.text = $"-{randomDamage}";

        Debug.Log(slider.value);

        EndBattle();
    }

    private void TakeDamage(int damage)
    {
        hp -= damage;
    }

    private void EndBattle()
    {
        if (hp <= 0)
        {
            AfterEndBattle();
        }
    }

    private void AfterEndBattle()
    {
        CollectRewards();
        PlayerState.wonBattles++;
        victory.SetActive(true);
    }

    private void CollectRewards()
    {
        Game.UpdateExp(150);
        Game.UpdateGold(Utils.RandomValue(100, 500));
    }

    // Update is called once per frame
    private void Update()
    {
    }
}