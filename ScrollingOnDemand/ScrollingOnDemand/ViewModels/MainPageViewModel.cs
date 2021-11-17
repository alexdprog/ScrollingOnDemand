using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using Newtonsoft.Json;

using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

using ScrollingOnDemand.Models;

namespace ScrollingOnDemand.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private IList<ListItem> _mainList;

        public IList<ListItem> MainList { get => _mainList; set => SetProperty(ref _mainList, value); }

        public DelegateCommand <ListItem> ExpandCommand { get; set; }
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            MainList = new List<ListItem> {new ListItem() };
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream("ScrollingOnDemand.Resources.ListItems.txt"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string listJson = reader.ReadToEnd();
                    try
                    {
                        MainList = JsonConvert.DeserializeObject<List<ListItem>>(listJson);
                    }
                    catch
                    {

                    }
                }
            }

            ExpandCommand = new DelegateCommand<ListItem>(ExpandExdecute);
        }

        void ExpandExdecute(ListItem item)
        {
            item.Expanded = !item.Expanded;
        }
    }
}
