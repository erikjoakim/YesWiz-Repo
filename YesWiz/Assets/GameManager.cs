using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static Player player;
    [SerializeField] Text StatusText;

    private static GameManager gm;
    private GameManager() { }

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
        
        player = FindObjectOfType<Player>();
        StatusText.text = "GM: Player: " + player + "\n";
        StatusText.text += "GM: UIText: " + StatusText + "\n";
        
    }
}
