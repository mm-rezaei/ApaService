
using ApaGroup.Framework.Basis.Enumerations;

namespace ApaGroup.Framework.Basis.Cores.EventTracker
{
    public delegate void EventTrackerHandler(object inTrackedSourceObject, string inEvent, LogType inType);
}
