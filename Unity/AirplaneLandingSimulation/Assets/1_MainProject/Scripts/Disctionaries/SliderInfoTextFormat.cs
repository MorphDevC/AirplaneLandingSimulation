using System.Collections.Generic;

public static class SliderInfoTextFormat
{
    public static Dictionary<PropertyTag, string> getStringFormat = new Dictionary<PropertyTag, string>()
    {
        { PropertyTag.Distance,"км"},
        { PropertyTag.AirplaneHeight,"м"},
        { PropertyTag.AirplaneSpeed,"км/ч"},
        { PropertyTag.GlidePathAngle,"°"}
    };
}
