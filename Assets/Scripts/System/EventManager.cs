using System;
using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivor
{
    public static class EventManager
    {
        private static Dictionary<GameEvents, Action<object>> eventDictionary = new();

        public static void StartListening(GameEvents eventName, Action<object> listener)
        {
            if (eventDictionary.TryGetValue(eventName, out var thisEvent))
            {
                thisEvent += listener;
                eventDictionary[eventName] = thisEvent;
            }
            else
            {
                thisEvent += listener;
                eventDictionary.Add(eventName, thisEvent);
            }
        }

        public static void StopListening(GameEvents eventName, Action<object> listener)
        {
            if (eventDictionary.TryGetValue(eventName, out var thisEvent))
            {
                thisEvent -= listener;
                eventDictionary[eventName] = thisEvent;
            }
        }

        public static void TriggerEvent(GameEvents eventName, object eventParam = null)
        {
            if (eventDictionary.TryGetValue(eventName, out var thisEvent))
            {
                thisEvent.Invoke(eventParam);
            }
        }
    }
}
