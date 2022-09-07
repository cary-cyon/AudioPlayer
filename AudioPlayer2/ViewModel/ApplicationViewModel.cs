﻿using AudioPlayer2.Commands;
using AudioPlayer2.Data;
using AudioPlayer2.Logic;
using AudioPlayer2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace AudioPlayer2.ViewModel
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private LocalDbContext _context;
        private AudioController _controller;
        private RelayCommand _play;
        private RelayCommand _pause;
        private RelayCommand _stop;
        private List<Audio> _audios;
        private Audio _selectedAudio;
        private Duration _duration;
        
        
        public ApplicationViewModel()
        {
            _context = new LocalDbContext();
            Audios = _context.Audios.ToList();
            _controller = new AudioController();
            _controller.SetDurationControlToPlayer(SetDuration);
        }
        #region Commands GetProperties
        public RelayCommand Play
        {
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

        public RelayCommand Stop
        {
            get
            {
                return _stop ?? (_stop = new RelayCommand(_controller.StopAudio));
            }
        }
        #endregion
        #region Properties for XAML Bindings
        public Duration Duration {
            get { return _duration; }
            set { _duration = value; OnPropertyChanged(nameof(Duration)); }
        }
        //If Audio Selected must be set AudioSource
        public Audio SelectedAudio
        {
            get { return _selectedAudio; }
            set
            {
                _selectedAudio = value;
                //set audioSource
                _controller.SetSource(_selectedAudio.FilePath);
                OnPropertyChanged(nameof(SelectedAudio));
            }
        }
        public List<Audio> Audios
        {
            get { return _audios; }
            set { _audios = value; OnPropertyChanged(nameof(Audios)); }
        }
        #endregion
        //Need for set Duration in MediaOpenedEvent
        public void SetDuration(Duration duration)
        {
            Duration = duration;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
