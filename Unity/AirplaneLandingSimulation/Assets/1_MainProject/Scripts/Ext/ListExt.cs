using System.Collections.Generic;
using System.Linq;

public static class ListExt
{
    public static float GetTargetOptionByTag(this List<AirplaneOptions> targetList, PropertyTag targetTag)
    {
        return targetList.First(element=>element.targetPropertyTag.Equals(targetTag)).targetPropertyValue.OptionalValue;
    }
}
 