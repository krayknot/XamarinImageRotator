using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using Xamarin.Forms;
using ImageSource = Xamarin.Forms.ImageSource;

namespace Krayknot.Pages
{

    public class PropertyImages
    {
        public string ImageUrl { get; set; }

    }

    public class ImageModel
    {
        public string Url { get; set; }
        public StreamImageSource Source { get; set; }
    }


    public partial class ClassifiedImages : ContentPage
    {
        private ViewModels.Images classified = new ViewModels.Images();
        int _classifiedId;
        int imagesCount;

        readonly string accommodationImagesPath = "<images path. can be a url or stream or collection>";

        public ClassifiedImages(int classifiedId)
        {
            InitializeComponent();
            _classifiedId = classifiedId;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Initialize();
        }

        async private void Initialize()
        {

            classified = await new Services.ClassifiedServices().GetImages(_Id);

            // Step 2: Download the images and create a list of ImageModel objects
            var httpClient = new HttpClient();
            var imageModels = new List<ImageModel>();

            if (classified.Classified_ImageOne != null)
            {
                var imageBytes1 = await httpClient.GetByteArrayAsync(accommodationImagesPath + classified.Classified_ImageOne);
                var streamImageSource1 = ImageSource.FromStream(() => new MemoryStream(imageBytes1));
                var imageModel1 = new ImageModel { Url = accommodationImagesPath + classified.Classified_ImageOne, Source = (StreamImageSource)streamImageSource1 };
                imageModels.Add(imageModel1);
            }

            if (classified.Classified_ImageTwo != null)
            {
                var imageBytes2 = await httpClient.GetByteArrayAsync(accommodationImagesPath + classified.Classified_ImageTwo);
                var streamImageSource2 = ImageSource.FromStream(() => new MemoryStream(imageBytes2));
                var imageModel2 = new ImageModel { Url = accommodationImagesPath + classified.Classified_ImageTwo, Source = (StreamImageSource)streamImageSource2 };
                imageModels.Add(imageModel2);
            }

            if (classified.Classified_ImageThree != null)
            {
                var imageBytes3 = await httpClient.GetByteArrayAsync(accommodationImagesPath + classified.Classified_ImageThree);
                var streamImageSource3 = ImageSource.FromStream(() => new MemoryStream(imageBytes3));
                var imageModel3 = new ImageModel { Url = accommodationImagesPath + classified.Classified_ImageThree, Source = (StreamImageSource)streamImageSource3 };
                imageModels.Add(imageModel3);
            }

            if (classified.Classified_ImageFour != null)
            {
                var imageBytes4 = await httpClient.GetByteArrayAsync(accommodationImagesPath + classified.Classified_ImageFour);
                var streamImageSource4 = ImageSource.FromStream(() => new MemoryStream(imageBytes4));
                var imageModel4 = new ImageModel { Url = accommodationImagesPath + classified.Classified_ImageFour, Source = (StreamImageSource)streamImageSource4 };
                imageModels.Add(imageModel4);
            }

            if (classified.Classified_ImageFive != null)
            {
                var imageBytes5 = await httpClient.GetByteArrayAsync(accommodationImagesPath + classified.Classified_ImageFive);
                var streamImageSource5 = ImageSource.FromStream(() => new MemoryStream(imageBytes5));
                var imageModel5 = new ImageModel { Url = accommodationImagesPath + classified.Classified_ImageFive, Source = (StreamImageSource)streamImageSource5 };
                imageModels.Add(imageModel5);
            }

            imagesCount = imageModels.Count;

            // Step 3: Bind the list of ImageModel objects to the CarouselView
            carouselView.ItemsSource = imageModels;

            //Update the UI on the main thread
            Device.BeginInvokeOnMainThread(() =>
            {
                // Set the IsRunning property of the ActivityIndicator control to false
                activityIndicatorList.IsRunning = false;
                activityIndicatorList.IsVisible = false;
            });

            if (classified.Classified_ImageOne != null)
            {
                ImageOne.Source = ImageSource.FromUri(new Uri(accommodationImagesPath + classified.Classified_ImageOne));
            }
            else
            {
                ImageOne.IsVisible = false;
            }

            if (classified.Classified_ImageTwo != null)
            {
                ImageTwo.Source = ImageSource.FromUri(new Uri(accommodationImagesPath + classified.Classified_ImageTwo));
            }
            else
            {
                ImageTwo.IsVisible = false;
            }

            if (classified.Classified_ImageThree != null)
            {
                ImageThree.Source = ImageSource.FromUri(new Uri(accommodationImagesPath + classified.Classified_ImageThree));
            }
            else
            {
                ImageThree.IsVisible = false;
            }

            if (classified.Classified_ImageFour != null)
            {
                ImageFour.Source = ImageSource.FromUri(new Uri(accommodationImagesPath + classified.Classified_ImageFour));
            }
            else
            {
                ImageFour.IsVisible = false;
            }

            if (classified.Classified_ImageFive != null)
            {
                ImageFive.Source = ImageSource.FromUri(new Uri(accommodationImagesPath + classified.Classified_ImageFive));
            }
            else
            {
                ImageFive.IsVisible = false;
            }
        }


        private void ChangePageBackground()
        {
        }

        async void BackButton_Tapped(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

        void OnClick_ImageOne(System.Object sender, System.EventArgs e)
        {
            carouselView.Position = 0;
            ChangePageBackground();
        }

        void OnClick_ImageTwo(System.Object sender, System.EventArgs e)
        {
            carouselView.Position = 1;
            ChangePageBackground();
        }

        void OnClick_ImageThree(System.Object sender, System.EventArgs e)
        {
            carouselView.Position = 2;
            ChangePageBackground();
        }

        void OnClick_ImageFour(System.Object sender, System.EventArgs e)
        {
            carouselView.Position = 3;
            ChangePageBackground();
        }

        void OnClick_ImageFive(System.Object sender, System.EventArgs e)
        {
            carouselView.Position = 4;
            ChangePageBackground();
        }

        private void MoveToPreviousButton_Clicked(object sender, EventArgs e)
        {
            if (carouselView.Position > 0)
            {
                carouselView.Position -= 1;
            }
        }

        private void MoveToNextButton_Clicked(object sender, EventArgs e)
        {
            if (carouselView.Position < imagesCount - 1)
            {
                carouselView.Position += 1;
            }
        }
    }
}

