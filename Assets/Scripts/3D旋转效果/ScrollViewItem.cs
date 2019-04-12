using System;
using System.Collections.Generic;
using UnityEngine;


public class ScrollViewItem : MonoBehaviour
{
    /// <summary>
    /// 开始索引
    /// </summary>
    private int curveOffSetIndex = 0;
    /// <summary>
    /// 曲线偏移指数
    /// </summary>
    public int CurveOffSetIndex
    {
        get { return this.curveOffSetIndex; }
        set { this.curveOffSetIndex = value; }
    }

    /// <summary>
    /// 运行时实际索引（在运行时计算）
    /// </summary>
    private int curRealIndex = 0;
    /// <summary>
    /// 当前索引
    /// </summary>
    public int RealIndex
    {
        get { return this.curRealIndex; }
        set { this.curRealIndex = value; }
    }

    /// <summary>
    /// 曲线中心偏移
    /// </summary>
    private float dCurveCenterOffset = 0.0f;
    /// <summary>
    /// 中心偏移
    /// </summary>
    public float CenterOffSet
    {
        get { return this.dCurveCenterOffset; }
        set { dCurveCenterOffset = value; }
    }
    private Transform mTrs;

    void Awake()
    {
        mTrs = this.transform;
        OnAwake();
    }

    void Start()
    {
        OnStart();
    }

    /// <summary>
    /// 更新项目的状态
    /// 1.位置
    /// 2.规模
    /// 3.“深度”是2D或z在3D中定位以设置前后项目
    /// </summary>
    /// <param name="xValue">x值</param>
    /// <param name="depthCurveValue">深度曲线值</param>
    /// <param name="depthFactor">深度因子</param>
    /// <param name="itemCount">子物体数量计数</param>
    /// <param name="yValue">y值</param>
    /// <param name="scaleValue">标度值</param>
    public void UpdateScrollViewItems(float xValue,float depthCurveValue,int depthFactor,float itemCount,float yValue,float scaleValue)
    {
        Vector3 targetPos = Vector3.one;
        Vector3 targetScale = Vector3.one;
        // position
        targetPos.x = xValue;
        targetPos.y = yValue;
        mTrs.localPosition = targetPos;

        //设置项目的“深度”
        //目标pos.z=深度值;
        SetItemDepth(depthCurveValue, depthFactor, itemCount);
        // 缩放
        targetScale.x = targetScale.y = scaleValue;
        mTrs.localScale = targetScale;
    }
    /// <summary>
    /// item的点击事件
    /// </summary>
    protected virtual void OnClickScrollViewItem()
    {
        ScrollView3D.GetInstance.SetHorizontalTargetItemIndex(this);
    }

    protected virtual void OnStart()
    {
    }

    protected virtual void OnAwake()
    {
    }
    /// <summary>
    /// 设置item深度
    /// </summary>
    /// <param name="depthCurveValue">深度曲线值</param>
    /// <param name="depthFactor">深度因子</param>
    /// <param name="itemCount">item数量</param>
    protected virtual void SetItemDepth(float depthCurveValue, int depthFactor, float itemCount)
    {
    }

    /// <summary>
    /// 设置item中心状态
    /// </summary>
    /// <param name="isCenter"></param>
    public virtual void SetSelectState(bool isCenter)
    {
    }
}

