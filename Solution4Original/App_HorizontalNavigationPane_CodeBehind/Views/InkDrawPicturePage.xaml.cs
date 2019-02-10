﻿using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

using App_HorizontalNavigationPane_CodeBehind.Helpers;
using App_HorizontalNavigationPane_CodeBehind.Services.Ink;

using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace App_HorizontalNavigationPane_CodeBehind.Views
{
    // For more information regarding Windows Ink documentation and samples see https://github.com/Microsoft/WindowsTemplateStudio/blob/master/docs/pages/ink.md
    public sealed partial class InkDrawPicturePage : Page, INotifyPropertyChanged
    {
        private StorageFile imageFile;

        private bool touchInkingButtonIsChecked = true;
        private bool mouseInkingButtonIsChecked = true;
        private bool saveImageButtonIsEnabled;
        private bool clearAllButtonIsEnabled;
        private InkStrokesService strokesService;
        private InkPointerDeviceService pointerDeviceService;
        private InkFileService fileService;
        private InkZoomService zoomService;

        public InkDrawPicturePage()
        {
            InitializeComponent();

            Loaded += (sender, eventArgs) =>
            {
                SetCanvasSize();
                image.SizeChanged += Image_SizeChanged;

                strokesService = new InkStrokesService(inkCanvas.InkPresenter);
                pointerDeviceService = new InkPointerDeviceService(inkCanvas);
                fileService = new InkFileService(inkCanvas, strokesService);
                zoomService = new InkZoomService(canvasScroll);
                strokesService.StrokesCollected += (s, e) => RefreshEnabledButtons();
                strokesService.StrokesErased += (s, e) => RefreshEnabledButtons();
                strokesService.ClearStrokesEvent += (s, e) => RefreshEnabledButtons();
                pointerDeviceService.DetectPenEvent += (s, e) => TouchInkingButtonIsChecked = false;
            };
        }

        public bool TouchInkingButtonIsChecked
        {
            get => touchInkingButtonIsChecked;
            set
            {
                Set(ref touchInkingButtonIsChecked, value);
                pointerDeviceService.EnableTouch = value;
            }
        }

        public bool MouseInkingButtonIsChecked
        {
            get => mouseInkingButtonIsChecked;
            set
            {
                Set(ref mouseInkingButtonIsChecked, value);
                pointerDeviceService.EnableMouse = value;
            }
        }

        public bool SaveImageButtonIsEnabled
        {
            get => saveImageButtonIsEnabled;
            set => Set(ref saveImageButtonIsEnabled, value);
        }

        public bool ClearAllButtonIsEnabled
        {
            get => clearAllButtonIsEnabled;
            set => Set(ref clearAllButtonIsEnabled, value);
        }

        private void SetCanvasSize()
        {
            inkCanvas.Width = Math.Max(canvasScroll.ViewportWidth, 1000);
            inkCanvas.Height = Math.Max(canvasScroll.ViewportHeight, 1000);
        }

        private void Image_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Height == 0 || e.NewSize.Width == 0)
            {
                SetCanvasSize();
            }
            else
            {
                inkCanvas.Width = e.NewSize.Width;
                inkCanvas.Height = e.NewSize.Height;
            }
        }

        private void ZoomIn_Click(object sender, RoutedEventArgs e) => zoomService?.ZoomIn();

        private void ZoomOut_Click(object sender, RoutedEventArgs e) => zoomService?.ZoomOut();

        private void ResetZoom_Click(object sender, RoutedEventArgs e) => zoomService?.ResetZoom();

        private void FitToScreen_Click(object sender, RoutedEventArgs e) => zoomService?.FitToScreen();

        private async void LoadImage_Click(object sender, RoutedEventArgs e)
        {
            var file = await ImageHelper.LoadImageFileAsync();
            var bitmapImage = await ImageHelper.GetBitmapFromImageAsync(file);

            if (file != null && bitmapImage != null)
            {
                ClearAll();
                imageFile = file;
                image.Source = bitmapImage;
                zoomService?.FitToSize(bitmapImage.PixelWidth, bitmapImage.PixelHeight);

                RefreshEnabledButtons();
            }
        }

        private async void SaveImage_Click(object sender, RoutedEventArgs e) => await fileService?.ExportToImageAsync(imageFile);

        private void ClearAll_Click(object sender, RoutedEventArgs e) => ClearAll();

        private void ClearAll()
        {
            strokesService?.ClearStrokes();
            imageFile = null;
            image.Source = null;

            RefreshEnabledButtons();
        }

        private void RefreshEnabledButtons()
        {
            SaveImageButtonIsEnabled = image.Source != null && strokesService.GetStrokes().Any();
            ClearAllButtonIsEnabled = image.Source != null || strokesService.GetStrokes().Any();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }

            storage = value;
            OnPropertyChanged(propertyName);
        }

        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
