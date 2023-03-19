using MemoryTilesGame.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace MemoryTilesGame.ViewModels
{
    public class PictureViewModel : ObservableObject
    {
        private string _cardBackImagePath = Directory.GetCurrentDirectory() + @"\Images\default.png";

        private PictureModel _model;

        public int Id { get; private set; }

        private bool _isSelectable = true;

        private bool _isViewed;
        private bool _isMatched;
        private bool _isFailed;

        //Is being viewed by user
        public bool IsViewed
        {
            get
            {
                return _isViewed;
            }
            private set
            {
                _isViewed = value;
                OnPropertyChanged("SlideImage");
                OnPropertyChanged("IsSelectable");
            }
        }

        //Has been matched
        public bool IsMatched
        {
            get
            {
                return _isMatched;
            }
            private set
            {
                _isMatched = value;
                OnPropertyChanged("SlideImage");
                OnPropertyChanged("IsSelectable");
                OnPropertyChanged("IsMatched");
                OnPropertyChanged("IsVisible");
            }
        }

        public bool IsVisible
        {
            get
            {
                return !_isMatched;
            }

        }

        //Has failed to be matched
        public bool isFailed
        {
            get
            {
                return _isFailed;
            }
            private set
            {
                _isFailed = value;
                OnPropertyChanged("SlideImage");
                OnPropertyChanged("BorderBrush");
            }
        }

        //User can select this slide
        public bool IsSelectable
        {
            get
            {
                return !(IsViewed || IsMatched);
            }
            set
            {
                _isSelectable = value;
                OnPropertyChanged("IsSelectable");
            }
        }

        //Image to be displayed
        public string SlideImage
        {
            get
            {
                if (IsMatched)
                    return _model.ImageSource;
                if (IsViewed)
                    return _model.ImageSource;
                return _cardBackImagePath;
            }
        }


        public PictureViewModel(PictureModel model)
        {
            _model = model;
            Id = model.Id;
        }

        public PictureViewModel(int id, string imageSource)
        {
            Id = id;
            _model = new PictureModel(id, imageSource);
        }

        //Has been matched
        public void MarkMatched()
        {
            IsMatched = true;
        }

        //Has failed to match
        public void MarkFailed()
        {
            isFailed = true;
        }

        //No longer being viewed
        public void ClosePeek()
        {
            IsViewed = false;
            isFailed = false;
            OnPropertyChanged("SlideImage");
        }

        //Let user view
        public void Flip()
        {
            IsViewed = !IsViewed;
            OnPropertyChanged("SlideImage");
        }
    }
}