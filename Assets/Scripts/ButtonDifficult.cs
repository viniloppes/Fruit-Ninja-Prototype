using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDifficult : MonoBehaviour
{
    public int difficulty;

    private Button button;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = FindObjectOfType<GameManager>();
        button.onClick.AddListener(SetDifficult);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetDifficult()
    {
        Debug.Log(button.gameObject.name);
        gameManager.StartGame(difficulty);
    }
}
