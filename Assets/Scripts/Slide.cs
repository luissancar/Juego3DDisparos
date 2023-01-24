using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slide : MonoBehaviour
{
    public Slider staminaSlider;

    public float maxStamina = 100;
    private float currentStamina;
    private float staminaRegenerateStaminaTime = 0.1f;
    private float regenerateAmount = 2f;
    private float losingStaminaTime = 0.1f;

    Coroutine mCoroutineLosing;
    Coroutine mCoroutineRegenerate;

    // Start is called before the first frame update
    void Start()
    {
        currentStamina = maxStamina;
        staminaSlider.maxValue = maxStamina;
        staminaSlider.value = maxStamina;
        
    }

    public void UseStamina(float amount)
    {
        if (currentStamina - amount > 0)
        {
            if (mCoroutineLosing != null)
            {
                StopCoroutine(mCoroutineLosing);
            }
            mCoroutineLosing = StartCoroutine(LosingStaminaCoroutine(amount));
            if (mCoroutineRegenerate != null)
            {
                StopCoroutine(mCoroutineRegenerate);
            }
            mCoroutineRegenerate = StartCoroutine(RegenerateStamineCoroutine());
        }
    }

    private IEnumerator LosingStaminaCoroutine(float amount)
    {
        while (currentStamina >= 0) 
        {
            currentStamina -= amount;
            staminaSlider.value = currentStamina;
            yield return new WaitForSeconds(losingStaminaTime);
        }
        mCoroutineLosing = null;
        FindObjectOfType<PlayerMovement>().isSprinting = false;
    }


    private IEnumerator RegenerateStamineCoroutine() 
    {
        yield return new WaitForSeconds(1);
        while (currentStamina < maxStamina) 
        {
            currentStamina += regenerateAmount;
            staminaSlider.value = currentStamina;
            yield return new WaitForSeconds(staminaRegenerateStaminaTime);
        }
        mCoroutineRegenerate = null;
    }
}
