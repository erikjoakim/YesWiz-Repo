using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public HandleInput handleInput;
    public static Player player;

    private static GameManager gm;
    private GameManager() { }

    Text UIText;

    public static GameManager GM
    {
        get 
        {
            if (gm == null)
            {
                gm = new GameManager();
            }
            return gm;
        }
    }

    private void Start()
    {
        UIText = FindObjectOfType<Text>();
        player = FindObjectOfType<Player>();
        UIText.text = "GM: Player: " + player + "\n";
        UIText.text += "GM: UIText: " + UIText + "\n";
        print("GM: Player: " + player);
        print("GM: UIText: " + UIText);
    }
}
