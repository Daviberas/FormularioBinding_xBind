using FormularioBinding.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormularioBinding.ViewModels
{
    public class clsMainPageVM : clsVMBase
    {
        private clsPersona _personaSeleccionada;
        private ObservableCollection<clsPersona> _listado;
        private DelegateCommand _eliminarCommand;

        public clsMainPageVM()
        {

            rellenarLista();
            _eliminarCommand = new DelegateCommand(EliminarCommand_Executed, EliminarCommand_CanExecute);
        }

        private async void rellenarLista()
        {
            clsListado lista = new clsListado();
            _listado = await lista.getListado();
            NotifyPropertyChanged("listado");
        }

        public clsPersona personaSeleccionada
        {
            get
            {
                return _personaSeleccionada;
            }
            set
            {
                _personaSeleccionada = value;
                _eliminarCommand.RaiseCanExecuteChanged();
                NotifyPropertyChanged("personaSeleccionada");
            }
        }
        public ObservableCollection<clsPersona> listado
        {
            get
            {
                return _listado;
            }
        }

        public void btnEliminar_Click()
        {
            listado.Remove(personaSeleccionada);
        }

        public DelegateCommand eliminarCommand
        {
            get
            {
                return _eliminarCommand;
            }
        }

        private void EliminarCommand_Executed()
        {
            listado.Remove(personaSeleccionada);
        }

        private bool EliminarCommand_CanExecute()
        {
            bool puedeBorrar = false;
            if (personaSeleccionada != null)
                puedeBorrar = true;
            return puedeBorrar;
        }
    }
}
