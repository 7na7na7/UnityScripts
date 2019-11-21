using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject inventory;
    
    public float speed;


    private bool isinvenActive = true;
    void Update()
    {
        //이동(간단, 한줄)
        transform.Translate
        (Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 
            Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0);
        
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (isinvenActive) //인벤토리가 활성화되어 있다면
                {
                    inventory.SetActive(false); //인벤토리 비활성화
                    isinvenActive = false; //비활성화되었으므로 false
                }
                else //인벤토리가 활성화되어 있지 않다면
                {
                    inventory.SetActive(true); //인벤토리 활성화
                    isinvenActive = true; //활성화되었으므로 true
                }
            }
            
        
    }
    
}
