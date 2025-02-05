using Lofelt.NiceVibrations;
using TMPro;
using UnityEngine;

public class GameUI : Singleton<GameUI>
{
    [SerializeField] private TMP_Text _heightText;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        UpdateHeightUI();
        GameManager.Instance.OnHeightChanged += UpdateHeightUI;

    }
    private void OnDisable()
    {
        GameManager.Instance.OnHeightChanged -= UpdateHeightUI;
    }
    public void UpdateHeightUI()
    {
        Debug.Log("Updated Height Text");
        _heightText.text = GameManager.Instance.Height.ToString() + " cm";
    }
}
