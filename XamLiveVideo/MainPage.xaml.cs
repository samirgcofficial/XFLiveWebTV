using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MediaManager;
using MediaManager.Library;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamLiveVideo.Models;

namespace XamLiveVideo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            PerformVideoOperation();
        }

        private async Task PerformVideoOperation()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://www.streamingvideoprovider.com/");

                //▓ Get the Auth token from streamvideoproviders

                var response1 = await client.GetAsync("?l=api&a=svp_auth_get_token&api_key=" + "add your api key here" + "&api_code=" + "add your api code here");
                response1.EnsureSuccessStatusCode();
                var streamObj1 = await response1.Content.ReadAsStreamAsync();
                XmlSerializer serializer1 = new XmlSerializer(typeof(Response));
                var rootcontents1 = (Response)serializer1.Deserialize(streamObj1);

                //▓ Get the  list of videos from streamvideoproviders

                var response2 = await client.GetAsync("?l=api&a=svp_list_videos&token=" + rootcontents1.Auth_token);
                Preferences.Set("Token", rootcontents1.Auth_token);
                response2.EnsureSuccessStatusCode();
                var streamObj2 = await response2.Content.ReadAsStreamAsync();
                XmlSerializer serializer2 = new XmlSerializer(typeof(ApiVideoResponse));
                var rootcontents2 = (ApiVideoResponse)serializer2.Deserialize(streamObj2);

                Preferences.Set("CollectVideoLists", JsonConvert.SerializeObject(rootcontents2));
                //Filter the list get the exact the video that you want from lstreamvideoproviders
                var findlivestreamvideo = rootcontents2.Video_list.Video.Where(i => i.Title == "XamarinLiveTV").FirstOrDefault();
                if (findlivestreamvideo != null)
                {
                    //▓ Send the  auth token and videoref to api to  get m3u8 link which can be player from video player

                    var response3 = await client.GetAsync("?l=api&a=svp_get_hls_url&token=" + rootcontents1.Auth_token + "&video_ref=" + findlivestreamvideo.Ref_no);
                    response3.EnsureSuccessStatusCode();
                    var streamObj3 = await response3.Content.ReadAsStreamAsync();
                    XmlSerializer serializer3 = new XmlSerializer(typeof(CommonVideoFetchResponse));
                    var rootcontents3 = (CommonVideoFetchResponse)serializer3.Deserialize(streamObj3);

                    var item = await CrossMediaManager.Current.Extractor.CreateMediaItem(rootcontents3.Video_url);
                    item.MediaType = MediaType.Hls;
                    MyVideoView.Source = item;
                }
            }
            catch (Exception ex)
            {

            }
       
         }
    }
}
