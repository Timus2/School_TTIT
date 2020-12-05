using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VISwpf.Pages.ViewModel.Base
{
    class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Событие изменения свойств
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// <see cref="CallerMemberNameAttribute"/> автоматически определяет имя вызываемой переменной.
        /// </summary>
        /// <param name="propertyName">Имя переменной.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
