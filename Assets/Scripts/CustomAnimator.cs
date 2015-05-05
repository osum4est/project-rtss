using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CustomAnimator : MonoBehaviour {

	Image damageImage;
	public Color damageFlashColor;
	float damageFlashSpeed = 1f;
    float flinchMax = 5;
    float flinchSpeed = 30;
    float flinchXOrig;
    float flinchX;
    float flinchYOrig;
    float flinchY;
    bool flinch = false;

	bool playDamage = false;


	void Start()
	{
		damageImage = GameObject.Find("DamageImage").GetComponent<Image>();
	}

	public void PlayDamage()
	{
		playDamage = true;

        flinchYOrig = Random.Range(-1f, 1f) * flinchMax;
        flinchXOrig = Random.Range(-1f, 1f) * flinchMax;
        flinchY = flinchYOrig;
        flinchX = flinchXOrig;
        flinch = true;
	}
		
	void Update()
	{
		if (playDamage)
		{
			damageImage.color = damageFlashColor;
		}
		else
		{
			damageImage.color = Color.Lerp(damageImage.color, Color.clear, damageFlashSpeed * Time.deltaTime);
		}

        if (flinch)
        { 
            if (flinchY < .1f && flinchY > -.1f)
            {
                flinchY = -flinchYOrig;
                flinchX = -flinchXOrig;
                flinch = false;
            }     
        }

        flinchY = Mathf.Lerp(flinchY, 0, flinchSpeed * Time.deltaTime);
        flinchX = Mathf.Lerp(flinchX, 0, flinchSpeed * Time.deltaTime);
        Camera.main.transform.GetComponent<MouseLook>().AdjustY(flinchY);
        Globals.instance.me.transform.Rotate(0.0f, flinchX, 0.0f);

		playDamage = false;
	}
}
