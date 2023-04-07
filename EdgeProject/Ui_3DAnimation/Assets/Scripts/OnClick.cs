using UnityEngine;

public class OnClick : MonoBehaviour
{
    public int pressed;
    // public GameObject target; // The game object to look at
    public int Get_Default_Value;
    public static bool Hotspot;
    private void OnMouseDown()
    {
        if(Hower_Active.Howeractive ==true)
        {
            if (pressed == 0)
            {
                Hotspot = true;
                if (GUI_Control.instance.any_window_open == false)
                {
                    ClickController.instance.bAutoRotate = false;
                    GUI_Control.instance.OpenComponent("Outcome");
                    GUI_Control.instance.LoadingScreen.SetActive(true);
                    Get_Default_Value = int.Parse(this.gameObject.name);
                    ClickController.instance.SetDefault_Card_Value(Get_Default_Value);
                    Invoke("LoadingBar", 3f);
                    pressed = 1;
                    CancelInvoke();
                }

            }
            else
            {
                GUI_Control.instance.OpenComponent("Outcome");
                pressed = 0;
            }

        }


        // 

    }
    public void LoadingBar()
    {
        // int.TryParse(ImageToggleOnHover.instance.Get_Default_Value, out int guess);
     
        
        GUI_Control.instance.LoadingScreen.SetActive(false);
    }
}
