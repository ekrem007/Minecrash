using UnityEngine;
using UnityEngine.UI.Extensions;
using System.Collections.Generic;
public class WorldData : MonoBehaviour
{
    public static List<Player> Maps;
    public static int world;
    public GameObject levelPrefeb;
    int dem = 0;
    void Start()
    {
        Maps = new List<Player>();
        WorldMapdataloader();
        MapDraw();
    }
    void MapDraw()
    {
        dem = 0;
        for (int i = 0; i <= 4; i++)
            LoadLevelToGroup(i);
    }
    void LoadLevelToGroup(int i)
    {
        for (int j = 0; j < 5; j++)
            for (int k = -1; k <= 2; k++)
            {
                InsLevel(dem, i);
                dem++;
                if (dem == 99)
                    break;
            }
    }
    void InsLevel(int lv, int groupindex)
    {
        if (Maps[lv].UnLocked)
        {
            this.GetComponentInParent<HorizontalScrollSnap>().GoToScreen(groupindex);
        }
        Level level = Instantiate(levelPrefeb).GetComponent<Level>();
        level.map = Maps[lv];

        level.transform.SetParent(this.transform.GetChild(groupindex), false);
    }
    void WorldMapdataloader()
    {
        for (int i = world * 99; i < (world + 1) * 99; i++)
        {
            Maps.Add(DataLoader.DataPlayer[i]);
        }
    }
}