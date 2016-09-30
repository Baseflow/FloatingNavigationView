using System;
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Com.Andremion.Floatingnavigationview;

namespace Sample
{
    [Activity(Label = "Sample", MainLauncher = true, Icon = "@mipmap/icon", Theme="@style/AppTheme.NoActionBar")]
    public class MainActivity : AppCompatActivity, View.IOnClickListener, NavigationView.IOnNavigationItemSelectedListener
    {
        private FloatingNavigationView mFloatingNavigationView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            mFloatingNavigationView = FindViewById<FloatingNavigationView>(Resource.Id.floating_navigation_view);

            mFloatingNavigationView.SetOnClickListener(this);
            mFloatingNavigationView.SetNavigationItemSelectedListener(this);
        }

        public bool OnNavigationItemSelected(IMenuItem menuItem)
        {
            Snackbar.Make((View)mFloatingNavigationView.Parent, menuItem.TitleFormatted.ToString() + " Selected!", Snackbar.LengthShort).Show();
            mFloatingNavigationView.Close();
            return true;
        }

        public void OnClick(View v)
        {
            mFloatingNavigationView.Open();
        }

        public override void OnBackPressed()
        {
            if (mFloatingNavigationView.IsOpened)
            {
                mFloatingNavigationView.Close();
            }
            else {
                base.OnBackPressed();
            }
        }
    }
}

