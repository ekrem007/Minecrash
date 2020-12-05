using UnityEngine;


public class Effect : MonoBehaviour
{
    public static int bonusLighting = 0;
    public static int SetCount = 0;

    public static void SpawnNumber(Vector2 pos, GameObject obj, Sprite[] s, float time)
    {

        EffectTimer.isResetCombo = false;
        GameObject tmp = Instantiate(obj) as GameObject;
        int idx = EffectTimer.Combo / 3;
        if (idx > 12)
            idx = 12;
        if (!Menu.IsLose && !Menu.IsWin)
            MapLoader.score += (idx + 1) * 10;

        if (MapLoader.Mode == 0)
            GameObject.Find("Main Camera").GetComponent<Menu>().scoreinc((idx + 1) * 5);
        tmp.transform.Find("Render").GetComponent<SpriteRenderer>().sprite = s[idx];
        tmp.transform.localPosition = new Vector3(pos.x, pos.y, -0.4f);

        GameObject.Find("Screen").GetComponent<MapLoader>().Scoreupdate();

        EffectTimer.Combo++;
        bonusLighting++;
        SetCount++;

        if (bonusLighting == 21)
        {
            Editor.LightingRandomPoint();
            bonusLighting = 0;
        }
        if (SetCount == 30)
        {
            SetCount = 0;
            Editor.addLighting();
        }

        Destroy(tmp, time);
    }

    public static void SpawnSet(GameObject obj, GameObject SetPref, int power)
    {
        for (int i = 0; i < obj.transform.Find("Render").transform.childCount; i++)
            if (obj.transform.Find("Render").transform.GetChild(i) != null)
                Destroy(obj.transform.Find("Render").transform.GetChild(i).gameObject);

        GameObject tmp = Instantiate(SetPref) as GameObject;
        tmp.transform.parent = obj.transform.Find("Render");
        tmp.transform.localPosition = new Vector3(0, 0, -0.3f);
        if (power == 2)
            tmp.transform.Rotate(0, 0, -35);
        else
            tmp.transform.Rotate(0, 0, 35);
    }

    public static void SpawnStarWin(GameObject obj, GameObject StarPref, bool isshow)
    {
        for (int i = 0; i < obj.transform.Find("Render").transform.childCount; i++)
            if (obj.transform.Find("Render").transform.GetChild(i) != null)
                Destroy(obj.transform.Find("Render").transform.GetChild(i).gameObject);

        if (isshow)
            StarPref.transform.GetChild(0).GetComponent<Animator>().enabled = true;
        else
            StarPref.transform.GetChild(0).GetComponent<Animator>().enabled = false;
        GameObject tmp = Instantiate(StarPref) as GameObject;
        tmp.transform.parent = obj.transform.Find("Render");
        tmp.transform.localPosition = new Vector3(0, 0, -0.3f);
    }

    public static void SpawnBoom(Vector2 pos, GameObject obj, float time)
    {
        if (FindObjectOfType<Sound>() != null)
        {
            FindObjectOfType<Sound>().boom();
        }
        GameObject tmp = Instantiate(obj) as GameObject;
        tmp.transform.localPosition = new Vector3(pos.x, pos.y, -0.3f);
        Destroy(tmp, time);
    }

    public static void BlockClear(Vector2 pos, GameObject obj, int type, float time)
    {
        GameObject tmp = Instantiate(obj) as GameObject;
        tmp.transform.localPosition = new Vector3(pos.x, pos.y, -0.3f);
        string mtr = "";
        switch (type)
        {
            case 0:
                mtr = "gold";
                break;
            case 1:
                mtr = "blue";
                break;
            case 2:
                mtr = "lantern";
                break;
            case 3:
                mtr = "jack";
                break;
            case 4:
                mtr = "brick";
                break;
            case 5:
                mtr = "grass";
                break;
            case 6:
                mtr = "sand";
                break;
            case 9:
                Destroy(tmp);
                break;
            default:
                break;
        }
        tmp.GetComponent<ParticleSystemRenderer>().material = Resources.Load<Material>("Materials/" + mtr);
        Destroy(tmp, time);
    }

    public static void RowLighting(float y, GameObject obj)
    {
        if (FindObjectOfType<Sound>() != null)
        {
            FindObjectOfType<Sound>().elec();
        }
        GameObject tmp = Instantiate(obj) as GameObject;
        tmp.transform.localPosition = new Vector3(0, y, -0.3f);
        Destroy(tmp, 0.4f);
    }
    public static void ColumnLighting(float x, GameObject obj)
    {
        if (FindObjectOfType<Sound>() != null)
        {
            FindObjectOfType<Sound>().elec();
        }
        GameObject tmp = Instantiate(obj) as GameObject;
        tmp.transform.localPosition = new Vector3(x, -0.7f, -0.3f);
        Destroy(tmp, 0.4f);
    }
    public static void LightingPoint(Vector3 pos, GameObject obj)
    {
        if (FindObjectOfType<Sound>() != null)
        {
            FindObjectOfType<Sound>().bliz();
        }
        GameObject tmp = Instantiate(obj) as GameObject;
        tmp.transform.localPosition = new Vector3(pos.x, pos.y, -0.3f);
        Destroy(tmp, 0.5f);
    }


    public static void SpawnEnchan(GameObject obj, GameObject parent)
    {
        for (int i = 0; i < parent.transform.Find("Render").transform.childCount; i++)
            if (parent.transform.Find("Render").transform.GetChild(i) != null)
                Destroy(parent.transform.Find("Render").transform.GetChild(i).gameObject);

        GameObject tmp = Instantiate(obj) as GameObject;
        tmp.transform.parent = parent.transform.Find("Render");
        tmp.transform.localPosition = new Vector3(0.13f, 0.13f, -0.1f);
    }
    public static void SpawnType9(GameObject obj, GameObject parent)
    {
        for (int i = 0; i < parent.transform.Find("Render").transform.childCount; i++)
            if (parent.transform.Find("Render").transform.GetChild(i) != null)
                Destroy(parent.transform.Find("Render").transform.GetChild(i).gameObject);

        GameObject tmp = Instantiate(obj) as GameObject;
        tmp.transform.parent = parent.transform.Find("Render");
        tmp.transform.localPosition = new Vector3(0, 0, -0.1f);
    }
    public static void SpawnClock(GameObject obj, GameObject parent, Vector3 q)
    {
        for (int i = 0; i < parent.transform.Find("Render").transform.childCount; i++)
            if (parent.transform.Find("Render").transform.GetChild(i) != null)
                Destroy(parent.transform.Find("Render").transform.GetChild(i).gameObject);

        GameObject tmp = Instantiate(obj) as GameObject;
        tmp.transform.parent = parent.transform.Find("Render");
        tmp.transform.Rotate(q);
        tmp.transform.localPosition = new Vector3(0, 0, -0.3f);
    }


}
