using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [System.Serializable]
    public class Player
    {
        public int id;
        public GameObject PlayerGameObject;
        public string Tag;
    }
    public List<Player> Players;



    #region Singleton

    public static PlayerManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    #endregion 

}
