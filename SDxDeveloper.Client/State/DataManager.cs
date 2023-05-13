using SDxDeveloper.Domain.Models;
using System.Collections.Generic;

namespace SDxDeveloper.Client.State
{
    public static class DataManager
    {
        public static readonly List<SDxObjectInstance> LoadedObjects = new();
    }
}
