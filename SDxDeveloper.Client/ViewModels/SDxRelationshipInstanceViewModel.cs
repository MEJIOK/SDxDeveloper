using SDxDeveloper.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDxDeveloper.Client.ViewModels
{
    public sealed class SDxRelationshipInstanceViewModel
    {
        private SDxObjectInstance Instance { get; }

        public string? UID1 => Instance?.GetProperty("UID1");

        public string? UID2 => Instance?.GetProperty("UID2");

        public string? DefUID => Instance?.GetProperty("DefUID");

        public SDxRelationshipInstanceViewModel(SDxObjectInstance rel) => Instance = rel;
    }
}
