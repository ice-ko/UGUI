using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tween : MonoBehaviour
{
    Transform m_transform;
    /// <summary>
    /// 之前的比例
    /// </summary>
    Vector3 previousScale;
    float time;

    [Tooltip("开始出现时的UI大小设为真实大小的0.1倍")]
    public Vector3 setVector3;
    [Tooltip("动画曲线")]
    public AnimationCurve curve;
    [Tooltip("持续时间")]
    public float durationTime = 1;
    void Start()
    {
        previousScale = transform.localScale;
        m_transform = GetComponent<RectTransform>();
        transform.localScale = setVector3;
    }


    void Update()
    {
        time = Time.deltaTime * 10 / durationTime;
        //
        m_transform.localScale = Vector3.Lerp(transform.localScale,previousScale,curve.Evaluate(time));
    }
}
