using MoreMountains.Tools;
using TMPro;
using UnityEngine;

public class GameUI : Singleton<GameUI>
{
    [SerializeField] private TMP_Text _heightText;
    [SerializeField] private MMProgressBar _heightBar;
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
        _heightText.text = GameManager.Instance.Height.ToString() + " cm";

        _heightBar.UpdateBar(GameManager.Instance.GetMilestoneProgress(), 0, 1);
    }

}
