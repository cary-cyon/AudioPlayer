using AudioPlayer2.Commands;
using AudioPlayer2.Data;
using AudioPlayer2.Logic;
using AudioPlayer2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AudioPlayer2.ViewModel
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private AudioController _controller;
        private RelayCommand _play;
        private RelayCommand _pause;
        public RelayCommand Play {
            get
            {
                  return _play ??
                    (_play = new RelayCommand(_controller.PlayAudio));
            } 
        }
        public RelayCommand Pause 
        {
            get
            {
                return _pause ??
                    (_pause = new RelayCommand(_controller.PauseAudio));
            }
        }
        
        private RelayCommand Stop { get; set; }

        private LocalDbContext _context;
        public ApplicationViewModel()
        {
            _context = new LocalDbContext();
            Audios = _context.Audios.ToList();
            _controller = new AudioController();
        }
        private List<Audio> _audios;
        private Audio _selectedAudio;
        public Audio SelectedAudio {
            get { return _selectedAudio; }
            set { _selectedAudio = value; OnPropertyChanged(nameof(SelectedAudio)); } 
        }

        public List<Audio> Audios 
        {
            get { return _audios; }
            set { _audios = value; OnPropertyChanged("Audios");}
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
