using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class UGUIEnhanceItem : ScrollViewItem
{
    private Button uButton;
    private Image rawImage;

    protected override void OnStart()
    {
        rawImage = GetComponent<Image>();
        uButton = GetComponent<Button>();
        uButton.onClick.AddListener(OnClickUGUIButton);
    }

    private void OnClickUGUIButton()
    {
        OnClickScrollViewItem();
    }

    // Set the item "depth" 2d or 3d
    protected override void SetItemDepth(float depthCurveValue, int depthFactor, float itemCount)
    {
        int newDepth = (int)(depthCurveValue * itemCount);
        this.transform.SetSiblingIndex(newDepth);
    }

    public override void SetSelectState(bool isCenter)
    {
        if (rawImage == null)
            rawImage = GetComponent<Image>();
        rawImage.color = isCenter ? Color.white : Color.gray;
    }
}
