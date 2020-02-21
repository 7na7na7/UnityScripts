using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByClick : MonoBehaviour
{
    private int Cx, Cy, Tx, Ty;
    private AStar_PathFinding pf;
    void Start()
    {
        pf = FindObjectOfType<AStar_PathFinding>();
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.transform.position=new Vector3(pf.Charactor.transform.position.x,pf.Charactor.transform.position.y,Camera.main.transform.position.z);
       if(pf.dir==Vector3.zero)
       {
           //if(Input.GetTouch(0).phase==TouchPhase.Began)
           if (Input.GetMouseButtonDown(1))
           {
               print("A");
               Cx = Mathf.RoundToInt(pf.Charactor.transform.position.x);
               Cy = Mathf.RoundToInt(pf.Charactor.transform.position.y);
               Tx = Mathf.RoundToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition).x);
               Ty = Mathf.RoundToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

               if (Tx >= Cx && Ty >= Cy) //오른쪽 위
               {
                   print("오른쪽위");
                   pf.PathFinding(new Vector2Int(Cx - 10, Cy - 10), new Vector2Int(Tx + 10, Ty + 10),
                       new Vector2Int(Cx, Cy), new Vector2Int(Tx, Ty));
               }
               else if (Tx <= Cx && Ty >= Cy) //왼쪽 위
               {
                   print("왼쪽위");
                   pf.PathFinding(new Vector2Int(Tx - 10, Cy - 10), new Vector2Int(Cx + 10, Ty + 10),
                       new Vector2Int(Cx, Cy), new Vector2Int(Tx, Ty));
               }
               else if (Tx >= Cx && Ty <= Cy) //오른쪽 아래
               {
                   print("오른쪽아래");
                   pf.PathFinding(new Vector2Int(Cx - 10, Ty - 10), new Vector2Int(Tx + 10, Cy + 10),
                       new Vector2Int(Cx, Cy), new Vector2Int(Tx, Ty));
               }
               else if (Tx <= Cx && Ty <= Cy) //왼쪽 아래
               {
                   print("왼쪽아래");
                   pf.PathFinding(new Vector2Int(Tx - 10, Ty - 10), new Vector2Int(Cx + 10, Cy + 10),
                       new Vector2Int(Cx, Cy), new Vector2Int(Tx, Ty));
               }
           }
       }
    }
}
