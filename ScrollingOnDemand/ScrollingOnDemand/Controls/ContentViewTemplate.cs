using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace  ScrollingOnDemand.Controls
{
    /// <summary>
    /// ContentView с скроллом из шаблона
    /// </summary>
    public class ContentViewTemplate: ContentView
    {
        public ScrollView scrollView { get; set; }
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            scrollView = (ScrollView)GetTemplateChild("ScrollMain");
        }
    }
}
