﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.View;
using Java.Lang;

namespace TabLayoutDemo
{
    public class MySecondAdapter : PagerAdapter
    {
        public override int Count => throw new NotImplementedException();

        public override bool IsViewFromObject(View view, Java.Lang.Object @object)
        {
            throw new NotImplementedException();
        }
        
    }
}