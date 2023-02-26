using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_skill : MonoBehaviour
{
    public Image Skill;
    public Image SkillBack;
    public void InputSkill()
    {
        Skill.gameObject.SetActive(true);
        SkillBack.gameObject.SetActive(true);
    }
}
