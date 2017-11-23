using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace TabLayoutDemo
{
    public class TabFragment1 : Android.Support.V4.App.Fragment
    {
        public string CurrentText { get; set; }
        
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            var v = inflater.Inflate(Resource.Layout.TabLayout1, container, false);
            var etInput=v.FindViewById<EditText>(Resource.Id.etInput);
            etInput.TextChanged += EtInput_TextChanged;
            return v;
        }

        private void EtInput_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            this.CurrentText = ((EditText)sender).Text;
        }
    }
}