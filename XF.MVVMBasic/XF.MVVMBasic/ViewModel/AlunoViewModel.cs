using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XF.MVVMBasic.Model;
using XF.MVVMBasic.View;
using System.Threading.Tasks;

namespace XF.MVVMBasic.ViewModel
{
    public class AlunoViewModel : INotifyPropertyChanged
    {
        #region Propriedades

        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; NotifyPropertyChanged(); }
        }




        private string _Nome;

        public string Nome
        {
            get { return _Nome; }
            set { _Nome = value; NotifyPropertyChanged(); }
        }



        private string _RM;

        public string RM
        {
            get { return _RM; }
            set { _RM = value; NotifyPropertyChanged(); }
        }





        private ObservableCollection<Aluno> _lstAlunos;

        public ObservableCollection<Aluno> lstAlunos
        {
            get { return _lstAlunos; }
            set
            {
                _lstAlunos = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand NovoCommand { get; private set; }
        public ICommand SalvarCommand { get; private set; }
        public ICommand CancelarCommand { get; private set; }




        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        public AlunoViewModel()
        {
            _lstAlunos = new ObservableCollection<Aluno>();
            NovoCommand = new Command(ShowNovoAlunoView);
           
            GetAluno();
        }

        public AlunoViewModel(Aluno aluno)
        {
            this._RM = aluno.RM;
            this._Nome = aluno.Nome;
            this._Email = aluno.Email;
            SalvarCommand = new Command(SalvarAluno);
            CancelarCommand = new Command(BackAlunoView);
        }


        private void SalvarAluno()
        {
            _lstAlunos.Add(new Aluno() { Id = new Guid(), Email = _Email, Nome = _Nome, RM = _RM });
            App.Current.MainPage = new AlunoView();
        }

        private void BackAlunoView()
        {
            throw new NotImplementedException();
        }

        public void ShowNovoAlunoView()
        {
            App.Current.MainPage.Navigation.PushAsync(new NovoAlunoView());
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }




        public ObservableCollection<Aluno> GetAluno()
        {
            var aluno1 = new Aluno()
            {
                Id = Guid.NewGuid(),
                RM = "542621",
                Nome = "Anderson Silva",
                Email = "anderson@ufc.com"
            };
            var aluno2 = new Aluno()
            {
                Id = Guid.NewGuid(),
                RM = "1111111",
                Nome = "Jeferson Silva",
                Email = "jeferson@ufc.com"
            };
            var aluno3 = new Aluno()
            {
                Id = Guid.NewGuid(),
                RM = "2222222",
                Nome = "Emerson Silva",
                Email = "Emerson@ufc.com"
            };


            _lstAlunos.Add(aluno1);
            _lstAlunos.Add(aluno2);
            _lstAlunos.Add(aluno3);

            return _lstAlunos;
        }
    }
}
