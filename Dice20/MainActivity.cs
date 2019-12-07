using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Java.Util;
using static Dice20.Resource;

namespace Dice20
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private ImageView imageViewDice;
        private TextView textViewNum;
        private TextView textViewHit;
        private Random rng = new Random();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //new code

            int resID = Resources.GetIdentifier("image_view_dice", "id",PackageName);
            imageViewDice = (ImageView)FindViewById(resID);

            int resID1 = Resources.GetIdentifier("number", "id", PackageName);
            textViewNum = (TextView)FindViewById(resID1);

            //textViewHit = FindViewById(R.id.text_view_hit);
         

            Final MediaPlayer mp = MediaPlayer.create(this, R.raw.dice_roll);

            final RotateAnimation rotate = new RotateAnimation(0, 720, Animation.RELATIVE_TO_SELF, 0.5f, Animation.RELATIVE_TO_SELF, 0.5f);
            rotate.setDuration(500);
            rotate.setInterpolator(new LinearInterpolator());

            imageViewDice.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v)
            {
                imageViewDice.startAnimation(rotate);
                mp.start();
                textViewNum.setText(R.string.blank);


                new Handler().postDelayed(new Runnable() {
                    @Override
                    public void run()
                {
                    rollDice();
                }
            }, 500); // Millisecond 1000 = 1 sec
        }
    });

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}