using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPUI : MonoBehaviour
{
    [SerializeField] private Image hpBar;
    [SerializeField] private TextMeshProUGUI hpText;
    
    private void OnEnable()
    {
        EventBus.Subscribe<PlayerDamagedEvent>(OnPlayerDamaged);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe<PlayerDamagedEvent>(OnPlayerDamaged);
    }

    private void OnPlayerDamaged(PlayerDamagedEvent e)
    {
        if (e.Player != this.transform.root.gameObject) return;
        
        float ratio = (float)e.NewHP / e.MaxHP;
        hpBar.fillAmount = ratio;

        if(hpText != null )
             hpText.text = e.NewHP.ToString();
    }
}
