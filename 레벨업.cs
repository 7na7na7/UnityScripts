using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class 레벨업 : MonoBehaviour
{
    private PlayerAbility ability;
   public int level;
   public Slider expSlider;
   public int[] levelExps;
   int currentExp=0;
   public Text levelText;
   private void Start() {
       ability=GetComponent<PlayerAbility>();
   }
   public void GetEXP(int value)
   {
       currentExp+=value;
       expSlider.value+=value;
        if (currentExp >= levelExps[level-1]) //레벨업시
        {
            currentExp-=levelExps[level-1];
            expSlider.maxValue=levelExps[level];
            expSlider.value=currentExp-levelExps[level-1];
            level++;
            LevelUp();
            levelText.text="Lv." +level;
        }
    }
   public void LoseEXP(int value)
   {
       //할까말까
   }
   public void LevelUp()
   {
ability.GetAbility();
   }
   public void LevelDown()
   {

   }
}
