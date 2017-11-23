using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using V4Fragment = Android.Support.V4.App.Fragment;
using V4FragmentManager = Android.Support.V4.App.FragmentManager;
using System.Collections.Generic;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.App;
using Android.OS;
using System;
using Android.Widget;

namespace TabLayoutDemo
{
    [Activity(Label = "TabLayoutDemo", MainLauncher = true,Theme = "@style/Theme.DesignDemo")]
    public class MainActivity : AppCompatActivity
    {
        ViewPager viewpager;
        Adapter mAdapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            
            //ViewPager  
            viewpager = FindViewById<Android.Support.V4.View.ViewPager>(Resource.Id.viewpager);
            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            setupViewPager(viewpager); //Calling SetupViewPager Method  
                                       //TabLayout  
            var tabLayout = FindViewById<TabLayout>(Resource.Id.tabs);
            tabLayout.SetupWithViewPager(viewpager);
            //FloatingActionButton  
            var fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += (sender, e) => {
                Snackbar.Make(fab, "Here's a snackbar!", Snackbar.LengthLong).SetAction("Action", v => Console.WriteLine("Action handler")).Show();
            };

            SetSupportActionBar(toolbar);
            SupportActionBar.SetIcon(Resource.Drawable.Icon);
        }

        void setupViewPager(Android.Support.V4.View.ViewPager viewPager)
        {
            mAdapter = new Adapter(SupportFragmentManager);
            mAdapter.AddFragment(new TabFragment1(), "First Fragment");
            mAdapter.AddFragment(new TabFragment2(), "Second Fragment");
            mAdapter.AddFragment(new TabFragment3(), "Third Fragment");
            mAdapter.AddFragment(new TabFragment4(), "Forth Fragment");
            viewPager.Adapter = mAdapter;
            viewpager.Adapter.NotifyDataSetChanged();

            viewpager.PageSelected += Viewpager_PageSelected;
            
        }

        private void Viewpager_PageSelected(object sender, ViewPager.PageSelectedEventArgs e)
        {
            if (e.Position == 3)
            {
                viewpager.PageSelected -= Viewpager_PageSelected;
                var text = (mAdapter.fragments[0] as TabFragment1).CurrentText;
                int tmp;
                if (!int.TryParse(text, out tmp))
                {
                    viewpager.CurrentItem = 0;
                    Toast.MakeText(this, "Please input a number in Fragment1", ToastLength.Long).Show();
                }
                viewpager.PageSelected += Viewpager_PageSelected;
            }
        }
    }

    public class PageChangeHandler :Java.Lang.Object, ViewPager.IOnPageChangeListener
    {
        List<Android.Support.V4.App.Fragment> fragmentList;
        ViewPager mViewPager;
        public PageChangeHandler(List<Android.Support.V4.App.Fragment> fragments,ViewPager viewPager)
        {
            fragments = fragmentList;
            mViewPager = viewPager;
        }
       
        public void Dispose()
        {
            this.Dispose();
        }

        public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
        {
            var abc = 123;
        }

        public void OnPageScrollStateChanged(int state)
        {
            var abc = 123;
        }

        public void OnPageSelected(int position)
        {
            if (position == 1)
            {
                mViewPager.SetCurrentItem(0,false);
            }
            

        }
    }
}

