using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Cell : MonoBehaviour
{
    [SerializeField] private Image image;        
    [SerializeField] private Sprite backSprite;  
    private Sprite frontSprite;                   

    private bool isOpen = false;
    private bool isMatched = false;
    private MemoryGame game;

    public void Init(MemoryGame gameManager, Sprite front)
    {
        game = gameManager;
        frontSprite = front;
        image.sprite = backSprite;
        isOpen = false;
        isMatched = false;
        transform.localScale = Vector3.one;
    }

    public void OnClick()
    {
        if (isOpen || isMatched || game.IsBusy) return;

        game.OnCellClicked(this);
    }

    public void Open()
    {
        isOpen = true;
        transform.DORotate(new Vector3(0, 90, 0), 0.25f).OnComplete(() =>
        {
            image.sprite = frontSprite;
            transform.DORotate(Vector3.zero, 0.25f);
        });
    }

    public void Close()
    {
        isOpen = false;
        transform.DORotate(new Vector3(0, 90, 0), 0.25f).OnComplete(() =>
        {
            image.sprite = backSprite;
            transform.DORotate(Vector3.zero, 0.25f);
        });
    }

    public void Hide()
    {
        isMatched = true;
        transform.DOScale(Vector3.zero, 0.3f).SetEase(Ease.InBack);
    }

    public Sprite GetFrontSprite() => frontSprite;
}
