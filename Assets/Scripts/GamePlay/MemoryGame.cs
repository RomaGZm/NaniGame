using Naninovel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryGame : MonoBehaviour
{
    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private Transform gridParent;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] List<Cell> cells = new();
    [SerializeField] private PlayScript playScript;

    private Cell first, second;

    public bool IsBusy { get; private set; }

    public void OnGameFinished()
    {
        playScript.Play();
    }
    public void Show()
    {

        GenerateSprites();
    }

    void GenerateSprites()
    {
        List<Sprite> allSprites = new();
        for (int i = 0; i < 8; i++)
        {
            allSprites.Add(sprites[i]);
            allSprites.Add(sprites[i]); 
        }

        for (int i = 0; i < allSprites.Count; i++)
        {
            Sprite temp = allSprites[i];
            int rand = Random.Range(i, allSprites.Count);
            allSprites[i] = allSprites[rand];
            allSprites[rand] = temp;
        }

        for (int i = 0; i < cells.Count; i++)
        {
            cells[i].Init(this, allSprites[i]);
            
            Button btn = cells[i].GetComponent<Button>();
            btn.onClick.AddListener(cells[i].OnClick);
        }
    }

    public void OnCellClicked(Cell clicked)
    {
        if (IsBusy) return;

        clicked.Open();

        if (first == null)
        {
            first = clicked;
        }
        else if (second == null)
        {
            second = clicked;
            StartCoroutine(CheckMatch());
        }
    }

    IEnumerator CheckMatch()
    {
        IsBusy = true;
        yield return new WaitForSeconds(0.6f);

        if (first.GetFrontSprite() == second.GetFrontSprite())
        {
            first.Hide();
            second.Hide();
            cells.Remove(first);
            cells.Remove(second);
        }
        else
        {
            first.Close();
            second.Close();
        }

        first = null;
        second = null;
        IsBusy = false;

        if (cells.Count == 0)
        {
            OnGameFinished();
        }
    }
}
