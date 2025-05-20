using UnityEngine;
using UnityEngine.UI;

public class EnemyHPUI : MonoBehaviour
{
    // Enemy는 참조형식
    private Health health;
    [SerializeField] private Image hpBar;


    private void Awake()
    {
        health = transform.root.GetComponent<Health>();
    }
    private void OnEnable()
    {
        health.OnTakeDamage += UpdateHP;
    }
    private void OnDisable()
    {
        health.OnTakeDamage -= UpdateHP;
    }


    public void UpdateHP(float dmg, Vector3 _)
    {
        hpBar.fillAmount = health.Current / health.Max;
    }
}
