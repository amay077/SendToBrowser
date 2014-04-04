using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Linq;
using System.Text.RegularExpressions;

namespace SendToBrowser
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    [IntentFilter (new[]{ Intent.ActionSend }, 
        Label = "@string/share_intent_name",
        Categories = new []{ Intent.CategoryDefault },
        DataMimeType = "text/plain" )]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var data = this.Intent.GetStringExtra(Intent.ExtraText);
            if (!String.IsNullOrEmpty(data)) 
            {
                var url = ExtractUrl(data);
                if (!String.IsNullOrEmpty(url)) 
                {
                    var intent = new Intent(Intent.ActionView);
                    intent.SetData(Android.Net.Uri.Parse(url));
                    this.StartActivity(intent);
                    
                    Finish();
                    return;                
                }
            } 
            
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            
            FindViewById<EditText>(Resource.Id.editFailed).Text = data;
        }

        string ExtractUrl(string data)
        {
            // via http://piyopiyocs.blog115.fc2.com/blog-entry-636.html
            var http = new Regex(@"(https?://[-_.!~*\'()a-zA-Z0-9;/?:@&=+$,%#]+)");
            var m = http.Match(data);
            return m.Value;
        }
    }
}


