using Microsoft.Practices.Prism.Commands;
using OnlabModule.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OnlabModule.ViewModels
{
    class AddTeamViewModel : BaseViewModel
    {
        private ObservableCollection<Team> teams = new ObservableCollection<Team>();

        public ObservableCollection<Team> Teams
        {
            get
            {
                return teams;
            }

            set
            {
                teams = value;
                NotifyPropertyChanged("Teams");
            }
        }

        private String teamName;

        public String TeamName
        {
            get
            {
                return teamName;
            }
            set
            {
                teamName = value;
                NotifyPropertyChanged("TeamName");
            }
        }

        private int teamScore;

        public int TeamScore
        {
            get { return teamScore; }
            set
            {
                teamScore = value;
                NotifyPropertyChanged("TeamScore");
            }
        }

        private string teamDetails;

        public string TeamDetails
        {
            get { return teamDetails; }
            set
            {
                teamDetails = value;
                NotifyPropertyChanged("TeamDetails");
            }
        }

        void AddTeamExecute()
        {
            if (teamName == null || teamName == "")
            {
                MessageBox.Show("Csapat hozzáadásához add meg a csapat nevét!", "Nincs csapatnév", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {
                foreach (Team team in teams)
                {
                    if (team.Name.Equals(teamName))
                    {
                        MessageBox.Show("Már van ilyen nevű csapat a listában! Válassz másik nevet!", "Foglalt csapatnév", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                }

                teams.Add(new Team { Name = teamName, Score = 0, Details = "new team" });
                MessageBox.Show("Új csapat hozzáadva!", "Sikeres rögzítés", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        bool CanAddTeamExecute()
        {
            return true;
        }

        public ICommand AddTeam { get { return new DelegateCommand(AddTeamExecute); } }
    }
}
