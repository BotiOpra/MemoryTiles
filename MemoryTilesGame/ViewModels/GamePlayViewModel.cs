using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace MemoryTilesGame.ViewModels
{
    public class GamePlayViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int NrRows { get; set; }
        public int NrColumns { get; set; }

        private int NrMatchLeft;

        private DispatcherTimer _peekTimer;
        private const int _peekTimeSeconds = 2;

        private ObservableCollection<PictureViewModel> _slides;
        public ObservableCollection<PictureViewModel> Slides
        {
            get { return _slides; }
            set
            {
                _slides = value;
                OnPropertyChanged("Slides");
            }
        }

        private bool _gridSelectable = true;
        public bool GridSelectable
        {
            get
            {
                return _gridSelectable;
            }
            set
            {
                _gridSelectable = value;
                OnPropertyChanged("GridSelectable");
            }
        }

        private bool _isRowVisible = false;

        public bool IsRowVisible
        {
            get { return _isRowVisible; }
            set
            {
                if (_isRowVisible != value)
                {
                    _isRowVisible = value;
                    OnPropertyChanged(nameof(IsRowVisible));
                    OnPropertyChanged(nameof(RowHeight));
                }
            }
        }

        public GridLength RowHeight => _isRowVisible ? new GridLength(50) : new GridLength(0);


        private PictureViewModel _firstSelected, _secondSelected;

        public GamePlayViewModel() { }

        public GamePlayViewModel(int nrRows, int nrColumns)
        {
            NrRows = nrRows;
            NrColumns = nrColumns;

            Debug.Assert(nrRows * nrColumns % 2 == 0);

            Random rndGen = new Random();

            Slides = new ObservableCollection<PictureViewModel>();
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory() + @"\Images\");
            int j = 0;
            for (int i = 0; i < (NrRows * NrColumns) / 2; i++)
            {
                if (j == files.Length)
                    j = 0;
                Slides.Add(new PictureViewModel(i, files[j]));
                Slides.Add(new PictureViewModel(i, files[j]));
                j++;
            }

            _firstSelected = null;
            _secondSelected = null;

            NrMatchLeft = Slides.Count / 2;

            _peekTimer = new DispatcherTimer();
            _peekTimer.Interval = new TimeSpan(0, 0, _peekTimeSeconds);
            _peekTimer.Tick += PeekTimer_Tick;
        }

        public async void TileClicked(PictureViewModel card)
        {
            card.Flip();

            if (_firstSelected == null)
                _firstSelected = card;
            else if (_secondSelected == null)
            {
                _secondSelected = card;
                GridSelectable = false;
                await Task.Delay(_peekTimeSeconds * 1000);
                if (IsMatch())
                {
                    _firstSelected.MarkMatched();
                    _secondSelected.MarkMatched();
                }
                else
                {
                    _firstSelected.Flip();
                    _secondSelected.Flip();
                }
                    //_peekTimer.Start();
                _firstSelected = null;
                _secondSelected = null;
                GridSelectable = true;

                if(NrMatchLeft == 0)
                {
                    GridSelectable = false;
                    IsRowVisible = true;
                    Console.WriteLine("You won");
                }
            }
        }

        public bool IsMatch()
        {
            Debug.Assert(_firstSelected != null && _secondSelected != null);

            if (_firstSelected.Id == _secondSelected.Id)
            {
                NrMatchLeft--;
                return true;
            }
            return false;
        }

        public void StartGame()
        {
            while (NrMatchLeft > 0)
            {

            }
        }

        private void PeekTimer_Tick(object sender, EventArgs e)
        {
            foreach (var slide in Slides)
            {
                if (!slide.IsMatched)
                {
                    slide.ClosePeek();
                }
            }
            _peekTimer.Stop();
            GridSelectable = true;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
