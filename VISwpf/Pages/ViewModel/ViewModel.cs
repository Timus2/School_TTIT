using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using VISwpf.Pages.ViewModel.Base;

namespace VISwpf.Pages.ViewModel
{
    class ViewModel : BaseViewModel
    {
        #region Private Member
        private Page currentPage;
        #endregion

        #region Public Propertyes
        public Page CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Command
        public ICommand OpenPageEmployees { get; set; }
        public ICommand OpenPageBriefings { get; set; }
        public ICommand OpenPageDivisions { get; set; }
        public ICommand OpenPagePositions { get; set; }
        #endregion

        #region Contructor
        public ViewModel()
        {
            CurrentPage = new PageEmployees();
            //Create command
            OpenPageEmployees = new RelayCommand(() =>
            {
                CurrentPage = new PageEmployees();
            });
            OpenPageBriefings = new RelayCommand(() =>
            {
                CurrentPage = new PageBriefings();
            });
            OpenPageDivisions = new RelayCommand(() =>
            {
                CurrentPage = new PageDivisions();

            });
            OpenPagePositions = new RelayCommand(() =>
            {
                CurrentPage = new PagePositions();
            });
           
        }
        #endregion     
    }
}
