using System;
using System.Collections.Generic;
using System.Text;

using Prism.Mvvm;

namespace ScrollingOnDemand.Models
{
    public class ListItem :BindableBase
    {
        private bool _expanded;

        public string Name { get; set; }

        public string ExpandName { get; set; }

        public bool Expanded
        {
            get => _expanded;
            set => SetProperty(ref _expanded, value);
        }
    }
}
